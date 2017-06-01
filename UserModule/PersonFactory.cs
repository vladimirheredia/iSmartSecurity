using System;

namespace UserModule
{
    public class PersonFactory
    {
        private static PersonFactory personInstance;

        private static Person personObject;

        private PersonFactory()
        {

        }

        /// <summary>
        /// Singleton PersonInstance object
        /// </summary>
        public static PersonFactory PersonInstance
        {
            get
            {
                if(personInstance == null)
                {
                    personInstance = new PersonFactory();
                }
                return personInstance;
            }
        }

        /// <summary>
        /// Creates object of person Employee is parameter passed is true else a visitor object
        /// </summary>
        /// <param name="isEmployee"></param>
        /// <returns></returns>
        public static Person CreatePerson(Boolean isEmployee)
        {
            if (isEmployee)
                personObject = new Employee();
            else
                personObject = new Visitor();

            return personObject;
        }
    }
}
