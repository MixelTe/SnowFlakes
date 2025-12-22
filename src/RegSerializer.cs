using Microsoft.Win32;
using System.Globalization;
using System.Text;

namespace SnowFlakes;

public class RegSerializer
{
	public static void Save(string keyName, object settings)
	{
		var t = settings.GetType();
		foreach (var fi in t.GetFields())
		{
			var v = fi.GetValue(settings);
			var n = fi.Name;

			if (n.StartsWith("DEV")) continue; //Don't save settings with "DEV" prefix

			//var s = string.Format(CultureInfo.InvariantCulture, "{0}", v);
			string s;
			var ft = fi.FieldType;
			if (v == null)
			{
				s = "";
			}
			else if (ft == typeof(Color))
			{
				var c = (Color)v;
				s = FormattableString.Invariant($"{c.A},{c.R},{c.G},{c.B}");
			}
			else if (ft == typeof(Size))
			{
				var c = (Size)v;
				s = FormattableString.Invariant($"{c.Width};{c.Height}");
			}
			else if (ft == typeof(Rectangle))
			{
				var c = (Rectangle)v;
				s = FormattableString.Invariant($"{c.X};{c.Y};{c.Width};{c.Height}");
			}
			else if (ft == typeof(Keys))
			{
				var c = (Keys)v;
				s = ((int)c).ToString(null, CultureInfo.InvariantCulture);
			}
			else if (v is ISerializable serializable)
			{
				s = serializable.Serialize();
			}
			else if (v is IFormattable f)
			{
				s = f.ToString(null, CultureInfo.InvariantCulture);
			}
			else
			{
				s = v.ToString() ?? "";
			}

			Registry.SetValue(keyName, n, s);
		}
	}
	public static void Load(string keyName, object settings)
	{
		var t = settings.GetType();
		foreach (var fi in t.GetFields())
		{
			var n = fi.Name;
			var s = (string?)Registry.GetValue(keyName, n, "");
			if (string.IsNullOrWhiteSpace(s)) continue;
			var ft = fi.FieldType;
			object v;
			if (ft == typeof(int))
			{
				v = int.Parse(s, CultureInfo.InvariantCulture);
			}
			else if (ft == typeof(float))
			{
				v = float.Parse(s, CultureInfo.InvariantCulture);
			}
			else if (ft == typeof(double))
			{
				v = double.Parse(s, CultureInfo.InvariantCulture);
			}
			else if (ft == typeof(bool))
			{
				v = bool.Parse(s);
			}
			else if (ft == typeof(string))
			{
				v = s;
			}
			else if (ft == typeof(Color))
			{
				var parts = s.Split(',');
				if (parts.Length != 4) throw new Exception($"Field [{n}] is invalid! Type: {ft}");
				var a = int.Parse(parts[0], CultureInfo.InvariantCulture);
				var r = int.Parse(parts[1], CultureInfo.InvariantCulture);
				var g = int.Parse(parts[2], CultureInfo.InvariantCulture);
				var b = int.Parse(parts[3], CultureInfo.InvariantCulture);
				v = Color.FromArgb(a, r, g, b);
			}
			else if (ft == typeof(Size))
			{
				var parts = s.Split(';');
				if (parts.Length != 2) throw new Exception($"Field [{n}] is invalid! Type: {ft}");
				var width = int.Parse(parts[0], CultureInfo.InvariantCulture);
				var height = int.Parse(parts[1], CultureInfo.InvariantCulture);
				v = new Size(width, height);
			}
			else if (ft == typeof(Rectangle))
			{
				var parts = s.Split(';');
				if (parts.Length != 4) throw new Exception($"Field [{n}] is invalid! Type: {ft}");
				var x = int.Parse(parts[0], CultureInfo.InvariantCulture);
				var y = int.Parse(parts[1], CultureInfo.InvariantCulture);
				var width = int.Parse(parts[2], CultureInfo.InvariantCulture);
				var height = int.Parse(parts[3], CultureInfo.InvariantCulture);
				v = new Rectangle(x, y, width, height);
			}
			else if (ft == typeof(Keys))
			{
				v = int.Parse(s, CultureInfo.InvariantCulture);
			}
			else if (fi.GetValue(settings) is ISerializable serializable)
			{
				v = serializable;
				serializable.Deserialize(s);
			}
			else
			{
				throw new Exception($"type of field [{n}] is not supported! Type: {ft}");
			}

			fi.SetValue(settings, v);
		}
	}

	public interface ISerializable
	{
		string Serialize();
		void Deserialize(string value);
	}

	public class SList<T> : List<T>, ISerializable where T : ISerializable, new()
	{
		public void Deserialize(string value)
		{
			Clear();

			if (string.IsNullOrEmpty(value))
				return;

			var buffer = new StringBuilder();

			for (int i = 0; i < value.Length; i++)
			{
				var c = value[i];
				if (c != ';') { buffer.Append(c); continue; }
				if (i + 1 < value.Length && value[i + 1] == ';')
				{
					buffer.Append(';');
					i++;
				}
				else
				{
					AddItem();
				}
			}
			AddItem();

			void AddItem()
			{
				var v = new T();
				v.Deserialize(buffer.ToString());
				Add(v);
				buffer.Clear();
			}
		}

		public string Serialize()
		{
			return string.Join(";", this.Select(v => v.Serialize().Replace(";", ";;")));
		}
	}
	public class SList_int : List<int>, ISerializable
	{
		public void Deserialize(string value)
		{
			Clear(); 
			foreach (var item in value.Split(";")) 
				Add(int.Parse(item, CultureInfo.InvariantCulture)); 
		}

		public string Serialize()
		{
			return string.Join(";", this.Select(v => v.ToString(null, CultureInfo.InvariantCulture)));
		}
	}
}