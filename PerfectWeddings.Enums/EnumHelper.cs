using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PerfectWeddings.Enums
{
    public class EnumHelper
    {
        public static IEnumerable<string> GetDescriptions(Type enumType)
        {
            var descs = new List<string>();
            foreach (var item in Enum.GetValues(enumType))
            {
                descs.AddRange(GetDescriptions(item as Enum));
            }
            return descs;
        }

        private static IEnumerable<string> GetDescriptions(Enum value)
        {
            var descs = new List<string>();
            var type = value.GetType();
            var name = Enum.GetName(type, value);
            var field = type.GetField(name);
            var fds = field.GetCustomAttributes(typeof(DescriptionAttribute), true);
            foreach (DescriptionAttribute fd in fds)
            {
                descs.Add(fd.Description);
            }
            return descs;
        }
    }
}
