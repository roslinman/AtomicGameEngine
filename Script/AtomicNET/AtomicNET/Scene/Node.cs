using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;

namespace AtomicEngine
{

    public partial class Node : Animatable
    {

        public Component CreateComponent<T>(CreateMode mode = CreateMode.REPLICATED, uint id = 0) where T : Component
        {
            var type = typeof(T);

            if (type.IsSubclassOf(typeof(CSComponent)))
            {
                var component = (CSComponent)Activator.CreateInstance(type);
                CSComponentCore.RegisterInstance(component);

                AddComponent(component, id, mode);

                return component;
            }

            return CreateComponent(type.Name, mode, id);
        }


    }

}
