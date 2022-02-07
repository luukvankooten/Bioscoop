using Core.DomainServices;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using System.IO;
using System.Reflection;

namespace Main
{
    public class ExportToJSON : IExportTo
    {
        public bool Export<T>(T obj)
        {
            try
            {
                string dir = Path.Combine(Directory.GetCurrentDirectory(), "exports");
                if (!Directory.Exists(dir))
                    Directory.CreateDirectory(dir);

                JsonSerializerSettings settings = new JsonSerializerSettings();
                settings.ConstructorHandling = ConstructorHandling.AllowNonPublicDefaultConstructor;

                CamelCasePropertyNamesContractResolver contractResolver = new CamelCasePropertyNamesContractResolver();
                contractResolver.DefaultMembersSearchFlags = contractResolver.DefaultMembersSearchFlags | BindingFlags.NonPublic;
                settings.ContractResolver = contractResolver;

                File.WriteAllText(Path.Combine(dir, $"{Path.GetFileNameWithoutExtension(Path.GetRandomFileName())}.json"), JsonConvert.SerializeObject(obj, Formatting.Indented, settings));
                return true;
            }
            catch
            {
                return false;
            }
        }
    }
}