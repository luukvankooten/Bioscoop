using Core.DomainServices;
using System.IO;

namespace Main
{
    public class ExportToTXT : IExportTo
    {
        public bool Export<T>(T obj)
        {
            try
            {
                string dir = Path.Combine(Directory.GetCurrentDirectory(), "exports");
                if (!Directory.Exists(dir))
                    Directory.CreateDirectory(dir);

                File.WriteAllText(Path.Combine(dir, $"{Path.GetFileNameWithoutExtension(Path.GetRandomFileName())}.txt"), ToString());
                return true;
            }
            catch
            {
                return false;
            }
        }
    }
}
