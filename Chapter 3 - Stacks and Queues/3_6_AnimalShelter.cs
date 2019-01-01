using System;
using System.Collections.Generic;
using NUnit.Framework;

namespace Chapter_3___Stacks_and_Queues
{
    /// <summary>
    /// Animal Shelter: An animal shelter, which holds only dogs and cats, operates on a strictly "first in, first
    /// out" basis. People must adopt either the "oldest" (based on arrival time) of all animals at the shelter,
    /// or they can select whether they would prefer a dog or a cat(and will receive the oldest animal of
    /// that type). They cannot select which specific animal they would like. Create the data structures to
    /// maintain this system and implement operations such as enqueue, dequeueAny, dequeueDog,
    /// and dequeueCat. You may use the built-in Linkedlist data structure.
    /// </summary>

    class AnimalQueue
    {
        Queue<Dog> dogQueue;
        Queue<Cat> catQueue;

        public AnimalQueue()
        {
            dogQueue = new Queue<Dog>();
            catQueue = new Queue<Cat>();
        }

        public void Enqueue(Animal animal)
        {
            animal.adoptionTime = DateTime.Now;

            if (animal is Dog)
            {
                dogQueue.Enqueue((Dog)animal);
                return;
            }
            if (animal is Cat)
            {
                catQueue.Enqueue((Cat)animal);
                return;
            }

            throw new Exception("Cannot enqueue unknown animal.");
        }

        public Animal DequeueAnyOldest()
        {
            if (catQueue.Count == 0 && dogQueue.Count == 0)
                throw new Exception("No animals to adopt.");

            if (catQueue.Count == 0)
                return DequeueDog();

            if (dogQueue.Count == 0)
                return DequeueCat();

            if (catQueue.Peek().adoptionTime > dogQueue.Peek().adoptionTime)
            {
                return DequeueCat();
            }

            return DequeueDog();
        }

        public Animal DequeueDog()
        {
            return dogQueue.Dequeue();
        }

        public Animal DequeueCat()
        {
            return catQueue.Dequeue();
        }
    }
    
    abstract class Animal
    {
        public DateTime adoptionTime;
        public string name;
    }

    class Dog : Animal
    {
        public Dog(string name)
        {
            this.name = name;
        }
    }

    class Cat : Animal
    {
        public Cat(string name)
        {
            this.name = name;
        }
    }

    public class _3_6_AnimalShelterTests
    {
        [Test]
        public void _3_6_AnimalShelter_WithValidEnqueues_ShouldDequeueSuccessfully()
        {
            AnimalQueue animalShelter = new AnimalQueue();

            Cat mittens = new Cat("Mittens");
            Cat fluffy = new Cat("Fluffy");
            Cat tiger = new Cat("Tiger");

            Dog sparky = new Dog("Sparky");
            Dog lassie = new Dog("Lassie");


            animalShelter.Enqueue(mittens);
            animalShelter.Enqueue(fluffy);
            animalShelter.Enqueue(tiger);

            animalShelter.Enqueue(sparky);
            animalShelter.Enqueue(lassie);

            Assert.AreEqual(animalShelter.DequeueDog(), sparky);

            Assert.AreEqual(animalShelter.DequeueCat(), mittens);
            Assert.AreEqual(animalShelter.DequeueCat(), fluffy);
            Assert.AreEqual(animalShelter.DequeueCat(), tiger);
            Assert.AreEqual(animalShelter.DequeueAnyOldest(), lassie);
        }
    }
}
