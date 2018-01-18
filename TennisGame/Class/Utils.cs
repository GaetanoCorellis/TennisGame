using System;
using System.Reflection;
using System.IO;
namespace TennisGame.Class {
    public static class Utils {
        /// <summary>
        /// Get the description of point in tennis language.
        /// </summary>
        /// <param name="point">Point to describe.</param>
        /// <returns>Description in tennis language.</returns>
        public static string GetPointDescription(int point) {
            if(!System.Enum.IsDefined(typeof(Enum.ScoreType), point)){
              throw new ArgumentOutOfRangeException();
            }
            return ((Enum.ScoreType)point).ToString();
        }

        /// <summary>
        /// Read from embedded json and convert in class.
        /// </summary>
        /// <typeparam name="T">Class in which to be converted.</typeparam>
        /// <param name="fileName">Name of the file to read.</param>
        /// <returns>Class initialized with data read from the json file.</returns>
        public static T GetClassFromEmbeddedJson<T>(string fileName) {
            T classOutput;
            using (StreamReader reader = ReadEmbeddedResource($"{nameof(TennisGame)}.Json.{fileName}.json")) {
                string json = reader.ReadToEnd();
                classOutput = Newtonsoft.Json.JsonConvert.DeserializeObject<T>(json);
            }
            return classOutput;
        }

        /// <summary>
        /// Read from embedded resource.
        /// </summary>
        /// <param name="path">Path of the file to read.</param>
        /// <returns>Streamreder resource.</returns>
        private static StreamReader ReadEmbeddedResource(string path) {
            Assembly assembly = Assembly.GetExecutingAssembly();
            return new StreamReader(assembly.GetManifestResourceStream(path));
        }
    }
}
