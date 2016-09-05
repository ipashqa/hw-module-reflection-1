using System;
using System.Collections;
using System.Collections.Generic;

using System.Reflection;

namespace HW_Reflection_1
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Enter full type name (for example: System.Int32, System.Double, System.Single): ");
            string typeName = Console.ReadLine();

            Type typeInList = Type.GetType(typeName);

            if (typeInList != null)
            {
                Type openType = typeof(List<>);
                Type closedType = openType.MakeGenericType(new Type[] { typeInList });

                object list = Activator.CreateInstance(closedType);

                MethodInfo addMethodInfo = closedType.GetMethod("Add");

                for (int i = 0; i < 5; i++)
                {
                    addMethodInfo.Invoke(list, new object[] { Activator.CreateInstance(typeInList) });

                    Console.WriteLine($"Value {i}: { ((IList)list)[i] }");
                }

                // The second variant (Easier): 
                // ((IList)list).Add(Activator.CreateInstance(typeInList));
            }
            else
            {
                Console.WriteLine("Specified type doesn't exist.");
            }

            Console.WriteLine("\nDone.");
            Console.ReadLine();
        }
    }
}
