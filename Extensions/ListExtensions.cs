using System.Collections.Generic;
using System.Linq;
using Tanaris.BO;
using Tanaris.Managers;

namespace Tanaris.Extensions
{
    internal static class ListExtensions
    {
        #region AllocatedMemory Lists

        public static void DisposeMemory(this List<AllocatedMemory> memory)
        {
            foreach(AllocatedMemory m in memory)
            {
                MemoryManager.BlackMagic.FreeMemory(m.Address);
            }

            memory.Clear();
        }

        public static AllocatedMemory GetFreeMemory(this List<AllocatedMemory> memory, int sizeOfAllocation)
        {
            foreach (AllocatedMemory m in memory)
                if (!m.Locked)
                {
                    m.Locked = true;
                    return m;
                }

            memory.Add(new AllocatedMemory(MemoryManager.BlackMagic.AllocateMemory(sizeOfAllocation)));
            return memory.Last();
        }

        #endregion
    }
}
