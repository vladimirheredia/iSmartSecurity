using System.Collections.Generic;
using UserModule;

namespace BehaviorModule
{
    /// <summary>
    /// Visitor Iterator class
    /// </summary>
    public class VisitorIterator : PersonIterator
    {
        private int position;
        IList<Visitor> Visitors;


        public VisitorIterator()
        {
            position = 0;
            Visitors = new List<Visitor>();
        }

        /// <summary>
        /// Gets current item from the list
        /// </summary>
        /// <returns></returns>
        public Person currentItem()
        {
            return Visitors[position];
        }

        /// <summary>
        /// gets first item from the list
        /// </summary>
        /// <returns></returns>
        public Person first()
        {
            return Visitors[0];
        }

        /// <summary>
        /// returns true if the list is done
        /// </summary>
        /// <returns></returns>
        public bool isDone()
        {
            if (Visitors.Count <= position)
                return true;
            else
                return false;
        }

        /// <summary>
        /// Gets next person in the list
        /// </summary>
        /// <returns></returns>
        public Person next()
        {
            return Visitors[position++];
        }
    }
}
