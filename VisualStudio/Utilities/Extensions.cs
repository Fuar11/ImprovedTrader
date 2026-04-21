// ---------------------------------------------
// Extensions - by The Illusion
// ---------------------------------------------
// Reusage Rights ------------------------------
// You are free to use this script or portions of it in your own mods, provided you give me credit in your description and maintain this section of comments in any released source code
//
// Warning !!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!
// Ensure you change the namespace to whatever namespace your mod uses, so it doesnt conflict with other mods
// ---------------------------------------------

namespace ImprovedTrader.Utilities
{
    /// <summary>
    /// Class containing all extensions
    /// </summary>
    public static class Extensions
    {
        /// <summary>
        /// Gets every class that is derived from another
        /// </summary>
        /// <typeparam name="T">The typeof for the base class</typeparam>
        /// <param name="constructorArgs">Any extra arguments</param>
        /// <returns>A list of classes that are derived from <typeparamref name="T"/></returns>
        public static System.Collections.Generic.IEnumerable<T>? GetEnumerableOfType<T>(params object[] constructorArgs) where T : class
        {
            if (typeof(T) == null) return null;

            System.Collections.Generic.List<T?> objects = new();

            foreach (var type in System.Reflection.Assembly.GetAssembly(typeof(T)).GetTypes().Where(
                t => t.IsClass
                && !t.IsAbstract
                && t.IsSubclassOf(typeof(T))
                ))
            {
                objects.Add(System.Activator.CreateInstance(type, constructorArgs) as T);
            }

            try
            {
                objects?.Sort();
            }
            catch (System.InvalidOperationException e)
            {
                Main.Logger.Log($"GetEnumerableOfType::Attempting to sort the objects list failed", FlaggedLoggingLevel.Exception, e);
            }

            // returns null if the list is null or has nothing in it
            return (objects == null) ? null : (objects.Count > 0) ? objects : null;
        }

        public static iTweenEvent Initialize(this iTweenEvent ite, string name, float rotation, float speed = 1f)
        {
            ite.animating = false;
            ite.playAutomatically = false;
            ite.tweenName = name;
            ite.type = iTweenEvent.TweenType.RotateBy;
            ite.vector3s = new Vector3[] { new Vector3(0, rotation, 0) };
            ite.floats = new float[] { speed };
            ite.keys = new string[] { "time", "amount" };
            ite.indexes = new int[] { 0, 0 };

            return ite;
        }

        public static ObjectAnim Initialize(this ObjectAnim oa, GameObject target)
        {
            oa.m_Target = target;
            oa.Start();

            return oa;
        }
    }
}
