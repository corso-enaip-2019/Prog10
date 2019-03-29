using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace PlugInSystem
{
    public class PlugInLoader
    {
        public List<IExercise> LoadAvailableExercises()
        {
            return LoadTypeList<IExercise>();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="T">Class type to use as reference. It load only final, concrete class that implemet that class</typeparam>
        /// <returns></returns>
        public List<T> LoadTypeList<T>()
        {
            List<T> _types = new List<T>();

            Assembly me = Assembly.GetExecutingAssembly();
            var list = me.GetTypes().Where(t => t != typeof(T) && typeof(T).IsAssignableFrom(t))
                .ToList();
            foreach (var type in list)
            {
                if (!type.IsAbstract)
                {
                    _types.Add((T)Activator.CreateInstance(type));
                }
            }
            return _types;
        }
    }
}
