using System;
using System.Globalization;

namespace Lab_4
{
    // Базовий клас Recipe
    public class Recipe
    {
        public string[] Ingredients { get; private set; }
        public string RecipeType { get; set; }

        // Віртуальний метод для приготування їжі
        public virtual void Cook()
        {
            Console.WriteLine("Приготування їжі.");
        }

        // Перевантажені методи для розрахунку часу приготування
        public virtual double CalculateCookingTime()
        {
            return Ingredients.Length * 5; // Стандартний розрахунок
        }

        public virtual double CalculateCookingTime(string difficultiesType)
        {
            // Якщо складність приготування не вказано або невідомо, повертаємо стандартний розрахунок
            Console.WriteLine("Невідома складність приготування. Використовується стандартний розрахунок.");
            return CalculateCookingTime();
        }

        // Встановлення кількості інгредієнтів з перевіркою коректності
        public void SetIngredients(string[] ingredients)
        {
            if (ingredients.Length > 0)
            {
                Ingredients = ingredients;
            }
            else
            {
                Console.WriteLine("Некоректна кількість інгредієнтів. Встановлено значення за замовчуванням.");
            }
        }
    }

    // Класс Salad (Салат), що успадковується від Recipe
    public class Salad : Recipe
    {
        public Salad()
        {
            RecipeType = "Салат";
            SetIngredients(new string[] { "Огірок", "Помідор" }); // Значення за замовчуванням
        }

        // Перевизначаємо метод Cook
        public override void Cook()
        {
            Console.WriteLine("Нарізання і змішування інгредієнтів.");
        }

        // Перевизначаємо метод для розрахунку часу приготування для салату
        public override double CalculateCookingTime()
        {
            return Ingredients.Length * 10; // Розрахунок часу приготування для салату
        }

        public override double CalculateCookingTime(string difficultiesType)
        {
            if (difficultiesType.ToLower() == "легко")
            {
                return Ingredients.Length * 5; // легко
            }
            else if (difficultiesType.ToLower() == "середньо")
            {
                return Ingredients.Length * 30; // середньо
            }
            else if (difficultiesType.ToLower() == "важко")
            {
                return Ingredients.Length * 60; // важко
            }
            return base.CalculateCookingTime(difficultiesType); // Стандартний розрахунок для інших типів
        }
    }

    // Клас Soup (Суп), що успадковує від Recipe
    public class Soup : Recipe
    {
        public Soup()
        {
            RecipeType = "Суп";
            SetIngredients(new string[] { "Картопля", "Морква", "Вода" }); // Значення за замовчуванням
        }

        // Перевизначаємо метод Cook
        public override void Cook()
        {
            Console.WriteLine("Варіння інгредієнтів.");
        }

        // Перевизначаємо метод для розрахунку часу приготування для супа
        public override double CalculateCookingTime()
        {
            return Ingredients.Length * 45; // Розрахунок часу приготування для супа
        }

        public override double CalculateCookingTime(string difficultiesType)
        {
            if (difficultiesType.ToLower() == "легко")
            {
                return Ingredients.Length * 5; // легко
            }
            else if (difficultiesType.ToLower() == "середньо")
            {
                return Ingredients.Length * 30; // середньо
            }
            else if (difficultiesType.ToLower() == "важко")
            {
                return Ingredients.Length * 60; // важко
            }
            return base.CalculateCookingTime(difficultiesType); // Стандартний розрахунок для інших типів
        }
    }

    // Клас Dessert (Десерт), що успадковує від Recipe
    public class Dessert : Recipe
    {
        public Dessert()
        {
            RecipeType = "Десерт";
            SetIngredients(new string[] { "Яйця", "Цукор", "Молоко", "Борошно", "Вишня" }); // Значення за замовчуванням
        }

        // Перевизначаємо метод Cook
        public override void Cook()
        {
            Console.WriteLine("Випікання або охолодження інгредієнтів.");
        }

        // Перевизначаємо метод для розрахунку часу приготування для десерта
        public override double CalculateCookingTime()
        {
            return Ingredients.Length * 60; // Розрахунок часу приготування для десерта
        }

        public override double CalculateCookingTime(string difficultiesType)
        {
            if (difficultiesType.ToLower() == "легко")
            {
                return Ingredients.Length * 5; // легко
            }
            else if (difficultiesType.ToLower() == "середньо")
            {
                return Ingredients.Length * 30; // середньо
            }
            else if (difficultiesType.ToLower() == "важко")
            {
                return Ingredients.Length * 60; // важко
            }
            return base.CalculateCookingTime(difficultiesType); // Стандартний розрахунок для інших типів
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Recipe food = null;
            bool isRunning = true;

            while (isRunning)
            {
                Console.WriteLine("Виберіть рецепт:");
                Console.WriteLine("1. Салат");
                Console.WriteLine("2. Суп");
                Console.WriteLine("3. Десерт");
                Console.WriteLine("4. Вийти");

                string choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        food = new Salad();
                        break;
                    case "2":
                        food = new Soup();
                        break;
                    case "3":
                        food = new Dessert();
                        break;
                    case "4":
                        isRunning = false;
                        continue;
                    default:
                        Console.WriteLine("Невірний вибір, спробуйте ще раз.");
                        continue;
                }

                // Приготування їжі
                food.Cook();

                // Вибір інгредієнтів
                Console.WriteLine("Чи бажаєте ввести власну кількість інгредієнтів? (Так/Ні)");
                string ingredientsChoice = Console.ReadLine().ToLower();
                if (ingredientsChoice == "так")
                {
                    bool validIngredients = false;
                    while (!validIngredients)
                    {
                        Console.WriteLine("Введіть кількість інгредієнтів:");
                        if (int.TryParse(Console.ReadLine(), out int ingredientsCount) && ingredientsCount >= 0)
                        {
                            string[] ingredients = new string[ingredientsCount];

                            for (int i = 0; i < ingredientsCount; i++)
                            {
                                Console.WriteLine($"Введіть інгредієнт {i + 1}:");
                                ingredients[i] = Console.ReadLine();
                            }

                            food.SetIngredients(ingredients);
                            validIngredients = true;
                        }
                        else
                        {
                            Console.WriteLine("Кількість інгредієнтів повинна бути більше 0. Спробуйте ще раз");
                        }
                    }
                }

                // Вибір варіанту розрахунку часу приготування
                string difficultiesType = "легко"; // За замовччуванням
                double cookingTime = 0;

                Console.WriteLine("Оберіть варіант розрахунку часу приготування:");
                Console.WriteLine("1. На основі кількості інгредієнтів");
                Console.WriteLine("2. На основі кількості інгредієнтів та складності приготування");

                string difficultiesChoice = Console.ReadLine();

                switch (difficultiesChoice)
                {
                    case "1":
                        cookingTime = food.CalculateCookingTime();
                        break;
                    case "2":
                        Console.WriteLine("Введіть складність приготування страви (Легко/Середньо/Важко):");
                        difficultiesType = Console.ReadLine();
                        cookingTime = food.CalculateCookingTime(difficultiesType);
                        break;
                    default:
                        Console.WriteLine("Невірний вибір. Використано стандартний розрахунок витрат.");
                        cookingTime = food.CalculateCookingTime();
                        break;
                }

                TextInfo ti = CultureInfo.CurrentCulture.TextInfo;

                // Виведення результату з докладною інформацією
                Console.WriteLine($"\nТип страви: {food.RecipeType}");
                Console.WriteLine($"Складність приготування: {ti.ToTitleCase(difficultiesType)}");
                Console.WriteLine($"Інгредієнти: {ti.ToTitleCase(string.Join(", ", food.Ingredients))}");
                Console.WriteLine($"Час приготування: {cookingTime} хв.\n");

                // Запит на продовження
                Console.WriteLine("Бажаєте вибрати інший рецепт? (Так/Ні)");
                if (Console.ReadLine().ToLower() != "так")
                {
                    isRunning = false;
                }
            }
        }
    }
}