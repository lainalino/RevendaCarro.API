using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RevendaCarro.API
{
    public class Animal : IAnimal
    {

        public string MakeSound()
        {
            return string.Empty;
        }
    }

    public class Dog : Animal
    {
        public override string MakeSound()
        {
            return "auau";
        }
    }

    public interface IAnimal
    {
        string MakeSound();
    }
}
