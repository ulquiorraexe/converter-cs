using System;

// IConverter arayüzü, sıcaklık, uzaklık, uzunluk ve hacim gibi farklı türlerdeki dönüşüm sınıflarının temelini oluşturur.
interface IConverter
{
    // Temel dönüşüm metodu: Belirli bir türdeki bir birimi diğerine dönüştürür.
    double Convert(double input);

    // Ters dönüşüm metodu: Belirli bir türdeki bir birimi diğerine geri dönüştürür.
    double ConvertBack(double input);
}

// TemperatureConverter sınıfı, sıcaklık birimlerini dönüştürmek için IConverter arayüzünü uygular.
class TemperatureConverter : IConverter
{
    // Fahrenheit'i Celsius'e dönüştüren metot
    public double Convert(double input)
    {
        return (input - 32) * 5 / 9;
    }

    // Celsius'i Fahrenheit'a dönüştüren metot
    public double ConvertBack(double input)
    {
        return input * 9 / 5 + 32;
    }
}

// DistanceConverter sınıfı, uzaklık birimlerini dönüştürmek için IConverter arayüzünü uygular.
class DistanceConverter : IConverter
{
    // Mil'i Kilometre'ye dönüştüren metot
    public double Convert(double input)
    {
        return input * 1.60934;
    }

    // Kilometre'yi Mil'e dönüştüren metot
    public double ConvertBack(double input)
    {
        return input / 1.60934;
    }
}

// LengthConverter sınıfı, uzunluk birimlerini dönüştürmek için IConverter arayüzünü uygular.
class LengthConverter : IConverter
{
    // Feet'i Centimeter'a dönüştüren metot
    public double Convert(double input)
    {
        return input * 30.48;
    }

    // Centimeter'ı Feet'e dönüştüren metot
    public double ConvertBack(double input)
    {
        return input / 30.48;
    }
}

// VolumeConverter sınıfı, hacim birimlerini dönüştürmek için IConverter arayüzünü uygular.
class VolumeConverter : IConverter
{
    // Gallon'u Litre'ye dönüştüren metot
    public double Convert(double input)
    {
        return input * 3.78541;
    }

    // Litre'yi Gallon'a dönüştüren metot
    public double ConvertBack(double input)
    {
        return input / 3.78541;
    }
}

// Program sınıfı, dönüşüm işlemlerini gerçekleştiren ana uygulama logic'ini içerir.
class Program
{
    static void Main()
    {
        int usageCount = 0;  // Programın kullanım sayısı

        while (true)
        {
            // Kullanıcıya seçenekleri göster
            Console.WriteLine("1. Fahrenheit to Celsius");
            Console.WriteLine("2. Celsius to Fahrenheit");
            Console.WriteLine("3. Miles to Kilometers");
            Console.WriteLine("4. Kilometers to Miles");
            Console.WriteLine("5. Feet to Centimeters");
            Console.WriteLine("6. Centimeters to Feet");
            Console.WriteLine("7. Gallons to Liters");
            Console.WriteLine("8. Liters to Gallons");
            Console.WriteLine("0. Exit");

            // Kullanıcının seçimini al
            Console.Write("Select an option: ");
            string input = Console.ReadLine();

            // Çıkış kontrol, input doğru mu kontrol ediyor
            if (input.ToLower() == "exit" || input == "0")
            {
                Console.WriteLine("Exiting the program. Goodbye!");
                break;
            }

            // Geçersiz giriş kontrolü
            if (!int.TryParse(input, out int choice) || choice < 0 || choice > 8)
            {
                Console.WriteLine("Invalid input. Please enter a valid option.");
                continue;
            }

            double result = 0;
            string conversionDescription = ""; // Dönüşüm açıklaması
            bool validInput = false; // Aşağıda kontrol ettiriyorum

            // Seçilen dönüşüm türüne göre işlemi gerçekleştir
            switch (choice)
            {
                case 1:
                case 2:
                    // Sıcaklık dönüşümü
                    validInput = GetUserInput("temperature", out double temperature);
                    if (validInput)
                    {
                        result = PerformConversion(new TemperatureConverter(), temperature, choice);
                        conversionDescription = (choice == 1) ? "Fahrenheit to Celsius" : "Celsius to Fahrenheit";
                    }
                    break;

                case 3:
                case 4:
                    // Uzaklık dönüşümü
                    validInput = GetUserInput("distance", out double distance);
                    if (validInput)
                    {
                        result = PerformConversion(new DistanceConverter(), distance, choice);
                        conversionDescription = (choice == 3) ? "Miles to Kilometers" : "Kilometers to Miles";
                    }
                    break;

                case 5:
                case 6:
                    // Uzunluk dönüşümü
                    validInput = GetUserInput("length", out double length);
                    if (validInput)
                    {
                        result = PerformConversion(new LengthConverter(), length, choice);
                        conversionDescription = (choice == 5) ? "Feet to Centimeters" : "Centimeters to Feet";
                    }
                    break;

                case 7:
                case 8:
                    // Hacim dönüşümü
                    validInput = GetUserInput("volume", out double volume);
                    if (validInput)
                    {
                        result = PerformConversion(new VolumeConverter(), volume, choice);
                        conversionDescription = (choice == 7) ? "Gallons to Liters" : "Liters to Gallons";
                    }
                    break;

                default:
                    Console.WriteLine("Invalid choice. Please enter a valid option.");
                    continue;
            }

            if (validInput)
            {
                // Sonucu görüntüle ve kullanım sayısını arttır
                Console.WriteLine($"Result of {conversionDescription}: {result}");
                usageCount++;
            }
        }

        // Programın kaç kez kullanıldığını görüntüle
        Console.WriteLine($"The program has been used {usageCount} times.");
    }

    // Kullanıcıdan giriş almak için yardımcı metot
    static bool GetUserInput(string inputName, out double inputValue)
    {
        inputValue = 0;
        bool validInput = false;

        while (!validInput)
        {
            Console.Write($"Enter {inputName}: ");
            if (double.TryParse(Console.ReadLine(), out inputValue))
            {
                validInput = true;
            }
            else
            {
                Console.WriteLine($"Invalid {inputName} input. Please enter a valid number.");
            }
        }

        return validInput;
    }

    // Belirli bir dönüşümü gerçekleştirmek için yardımcı metot
    static double PerformConversion(IConverter converter, double value, int choice)
    {
        // Dönüşümü gerçekleştir | X'ten mi Y'ye Y'den mi X'e 
        return (choice % 2 == 1) ? converter.Convert(value) : converter.ConvertBack(value);
    }
}