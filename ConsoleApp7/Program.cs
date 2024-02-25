main();

void main()
{
    PetShop petShop = new PetShop();

    Cat cat1 = new Cat("Tom", 5, "Male", 50.0);
    Cat cat2 = new Cat("Whiskers", 3, "Female", 40.0);

    petShop.AddCat(cat1);
    petShop.AddCat(cat2);

    petShop.ManageAnimals();

    Dog dog1 = new Dog("Buddy", 2, "Male", 100.0);
    Dog dog2 = new Dog("Daisy", 4, "Female", 90.0);

    petShop.AddDog(dog1);
    petShop.AddDog(dog2);

    Bird bird1 = new Bird("Tweetie", 1, "Male", 20.0);
    Bird bird2 = new Bird("Polly", 6, "Female", 30.0);

    petShop.AddBird(bird1);
    petShop.AddBird(bird2);

    Fish fish1 = new Fish("Goldie", 2, "Female", 15.0);
    Fish fish2 = new Fish("Nemo", 1, "Male", 25.0);

    petShop.AddFish(fish1);
    petShop.AddFish(fish2);

    Console.WriteLine($"Total Meal Quantity: {petShop.TotalMealQuantity()}");
    Console.WriteLine($"Total Cat Price: {petShop.TotalCatPrice()}");
}
class Animal
{
    public string Nickname { get; set; }
    public int Age { get; set; }
    public string Gender { get; set; }
    public int Energy { get; set; }
    public double Price { get; set; }
    public int MealQuantity { get; set; }

    public Animal(string nickname, int age, string gender, double price)
    {
        Nickname = nickname;
        Age = age;
        Gender = gender;
        Energy = 100;
        Price = price;
        MealQuantity = 0;
    }

    public virtual void Eat()
    {
        Energy += 20;
        MealQuantity++;
    }

    public virtual void Sleep()
    {
        Energy = 100;
    }

    public virtual void Play()
    {
        Energy -= 30;
    }
}

class Cat : Animal
{
    public Cat(string nickname, int age, string gender, double price) : base(nickname, age, gender, price){}

    public override void Eat()
    {
        base.Eat();
        Price *= 1.1; 
    }

    public override void Play()
    {
        base.Play();
        if (Energy <= 0)
        {
            Sleep();
        }
    }
}

class PetShop
{
    private Cat[] Cats;
    private Dog[] Dogs;
    private Bird[] Birds;
    private Fish[] Fishes;
    private int totalMealQuantity = 0;
    private double totalCatPrice = 0;

    public PetShop()
    {
        Cats = new Cat[0];
        Dogs = new Dog[0];
        Birds = new Bird[0];
        Fishes = new Fish[0];
    }

    public void AddCat(Cat cat)
    {
        Array.Resize(ref Cats, Cats.Length + 1);
        Cats[Cats.Length - 1] = cat;
    }

    public void AddDog(Dog dog)
    {
        Array.Resize(ref Dogs, Dogs.Length + 1);
        Dogs[Dogs.Length - 1] = dog;
    }

    public void AddBird(Bird bird)
    {
        Array.Resize(ref Birds, Birds.Length + 1);
        Birds[Birds.Length - 1] = bird;
    }

    public void AddFish(Fish fish)
    {
        Array.Resize(ref Fishes, Fishes.Length + 1);
        Fishes[Fishes.Length - 1] = fish;
    }

    public void RemoveByNickname(string nickname)
    {
        for (int i = 0; i < Cats.Length; i++)
        {
            if (Cats[i].Nickname == nickname)
            {
                for (int j = i; j < Cats.Length - 1; j++)
                {
                    Cats[j] = Cats[j + 1];
                }
                Array.Resize(ref Cats, Cats.Length - 1);
                break;
            }
        }
    }

    public void ManageAnimals()
    {
        foreach (var cat in Cats)
        {
            if (cat.Energy <= 0)
            {
                cat.Sleep();
            }
            totalMealQuantity += cat.MealQuantity;
            totalCatPrice += cat.Price;
        }
    }

    public int TotalMealQuantity()
    {
        return totalMealQuantity;
    }

    public double TotalCatPrice()
    {
        return totalCatPrice;
    }
}

class Dog : Animal
{
    public Dog(string nickname, int age, string gender, double price) : base(nickname, age, gender, price){}

    public override void Eat()
    {
        base.Eat();
        Price *= 1.1; 
    }

    public override void Play()
    {
        base.Play();
        if (Energy <= 0)
        {
            Sleep();
        }
    }
}

class Bird : Animal
{
    public Bird(string nickname, int age, string gender, double price) : base(nickname, age, gender, price){}
    public override void Eat()
    {
        base.Eat();
        Price *= 1.1; 
    }

    public override void Play()
    {
        base.Play();
        if (Energy <= 0)
        {
            Sleep();
        }
    }
}

class Fish : Animal
{
    public Fish(string nickname, int age, string gender, double price) : base(nickname, age, gender, price) {}
    public override void Eat()
    {
        base.Eat();
        Price *= 1.1; 
    }

    public override void Play()
    {
        base.Play();
        if (Energy <= 0)
        {
            Sleep();
        }
    }
}