using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Лабораторка
{
    internal class Program
    {

        static void Main(string[] args)
        {
            int ClientChoosen;
            int NumberNote = 0;
            int EditParamChoosen = -1;
            int NumberNoteLook = 0;
            int NumberNoteDelete = 0;

            bool CheckValid = false;
            bool BookIsOpen = true;
            bool ValidTestEdit = false;
            bool Valid = false;

            int QuantitiesNotes = 0;

            List<NoteBook> notebook = new List<NoteBook>();

            while (BookIsOpen)
            {
                Console.Clear();
                Console.WriteLine($"Добро пожаловать в вашу записную книжку." +
                    $" Количество записей на данный момент {notebook.Count}");
                Console.WriteLine("Выберите действие(введите цифру нужного варианта):");
                Console.WriteLine("1 - Создать новую запись");
                Console.WriteLine("2 - Редактировать существующую запись");
                Console.WriteLine("3 - Удалить запись");
                Console.WriteLine("4 - Просмотр записи");
                Console.WriteLine("5 - Просмотр всех записей");
                Console.WriteLine("0 - Закрыть записную книжку");

                ClientChoosen = Convert.ToInt32(Console.ReadLine());
                switch (ClientChoosen)
                {
                    case 1:
                        Console.Clear();
                        notebook.Add(new NoteBook());
                        notebook.Count();
                        notebook[notebook.Count() - 1].CreateNote();

                        break;
                    case 2:
                        Console.Clear();
                        ValidTestEdit = false;
                        if (notebook.Count == 0)
                        {
                            Console.WriteLine("Записи отсутвуют - создайте запись");
                            Console.WriteLine("Нажмите любую клавишу для продолжения");
                            Console.ReadKey();
                        }
                        else if (notebook.Count == 1)
                        {
                            while (ValidTestEdit == false)
                            {
                                Console.WriteLine("Существует одна запись. Введите 1 для продолжения");

                                try
                                {
                                    NumberNote = Convert.ToInt32(Console.ReadLine());
                                    if (NumberNote == 1)
                                    {
                                        Valid = true;
                                        ValidTestEdit = true;
                                        break;
                                    }
                                    else
                                    {
                                        Console.Clear();
                                        Console.WriteLine("Введено не число 1. Введите 1.");
                                        break;
                                    }
                                }
                                catch
                                {
                                    Console.WriteLine("Введено не число 1. Введите 1.");
                                }

                            }

                        }
                        else if (notebook.Count > 1)
                        {
                            Console.WriteLine($"Количество записей равняется: {notebook.Count}. " +
                                $"Выберите номер записи от 1 до {notebook.Count}");
                            NumberNote = Convert.ToInt32(Console.ReadLine());
                        }
                        if (NumberNote > 1 || Valid)
                        {
                            Console.Clear();
                            Console.WriteLine($"Выберите пункт, который хотите изменить: " +
                                $"\n1 - Фамилия: {notebook[NumberNote - 1].Surname}" +
                                $"\n2 - Имя: {notebook[NumberNote - 1].Name}" +
                                $"\n3 - Отчество: {notebook[NumberNote - 1].Patronymic}" +
                                $"\n4 - Номер телефона: {notebook[NumberNote - 1].NumberOfPhone}" +
                                $"\n5 - Страна: {notebook[NumberNote - 1].Country}" +
                                $"\n6 - День рождения: {notebook[NumberNote - 1].DayOfBirthday}" +
                                $"\n7 - Организация: {notebook[NumberNote - 1].Organization}" +
                                $"\n8 - Профессия: {notebook[NumberNote - 1].Profession}" +
                                $"\n9 - Описание: {notebook[NumberNote - 1].Description}" +
                                "\n0 - Отмена");
                            while (CheckValid == false)
                            {
                                try
                                {
                                    Console.WriteLine("Введеите число от 0 до 9(включительно)");
                                    EditParamChoosen = Convert.ToInt32(Console.ReadLine());
                                    if (EditParamChoosen < 0 || EditParamChoosen > 9)
                                    {
                                        Console.WriteLine("Введенное число за рамки возможных вариантов. Попробуйте ещё раз!");
                                        continue;
                                    }
                                    else
                                        CheckValid = true;

                                }
                                catch
                                {
                                    Console.Clear();
                                    Console.WriteLine("Введено не только цифры...Введите ещё раз!");
                                }
                            }
                            CheckValid = false;
                            if (EditParamChoosen == 0)
                            {
                                continue;
                            }
                            else
                            {
                                notebook[NumberNote - 1].EditNote(EditParamChoosen);
                            }

                        }


                        break;
                    case 3:
                        Console.Clear();
                        if (notebook.Count() == 0)
                        {
                            Console.WriteLine("Записей нет");
                            Console.ReadKey();
                            break;
                        }
                        while (CheckValid == false)
                        {
                            try
                            {
                                Console.Write("Введите номер записи, которую желаете удалить: ");
                                NumberNoteDelete = Convert.ToInt32(Console.ReadLine());
                                if (NumberNoteDelete > notebook.Count() || NumberNoteDelete <= 0)
                                {
                                    Console.WriteLine($"Введенное число выходит за рамки от 1 до {notebook.Count()} ");
                                    continue;
                                }
                                else
                                    CheckValid = true;

                            }
                            catch
                            {
                                Console.Clear();
                                Console.WriteLine("Введено не только цифры...Введите ещё раз!");
                            }

                        }
                        CheckValid = false;
                        notebook.RemoveAt(NumberNoteDelete - 1);

                        break;
                    case 4:
                        Console.Clear();
                        if (notebook.Count() == 0)
                        {
                            Console.WriteLine("Записей нет");
                            Console.ReadKey();
                            break;
                        }
                        while (CheckValid == false)
                        {
                            try
                            {
                                Console.Write("Введите номер записи, желаемой к просмотру: ");
                                NumberNoteLook = Convert.ToInt32(Console.ReadLine());
                                if (NumberNoteLook > notebook.Count() || NumberNoteLook <= 0)
                                {
                                    Console.WriteLine($"Введенное число выходит за рамки от 1 до {notebook.Count()} ");
                                    continue;
                                }
                                else
                                    CheckValid = true;
                            }
                            catch
                            {
                                Console.Clear();
                                Console.WriteLine("Введено не только цифры...Введите ещё раз!");
                            }

                        }
                        CheckValid = false;

                        notebook[NumberNoteLook - 1].ReadNote();
                        Console.ReadKey();

                        break;
                    case 5:
                        Console.Clear();
                        if (notebook.Count >= 1)
                        {
                            for (int i = 0; i < notebook.Count; i++)
                            {
                                Console.WriteLine(i + 1);
                                notebook[i].ShowAllNotes();
                            }
                        }
                        else
                        {
                            Console.WriteLine("Записей нет");
                            Console.ReadKey();
                        }
                        Console.ReadKey();
                        break;
                    case 0:
                        Console.Clear();
                        BookIsOpen = false;
                        break;
                }
            }
        }
    }
    public class NoteBook
    {
        public string Surname;
        public string Name;
        public string Patronymic;

        public int NumberOfPhone;

        public string Country;
        public string DayOfBirthday;
        public string Organization;
        public string Profession;
        public string Description;

        public void CreateNote()
        {
            List<string> Exlusions = new List<string>();
            Exlusions.AddRange(new string[] {"1","2","3","4","5","6","7","8","9","0","!","@","#","$","%","^",
            "&","*","(",")","<",">",",",".","?","/","}","{","]","[","|","~",":",";","№", " "});
            bool check = false;

            Console.WriteLine("Вы выбрали создание новой записи: ");
            Console.SetCursorPosition(4, 1);
            Console.WriteLine("...Создание новой записи...");
            Console.WriteLine("обязательные поля отмечены: '*'. \nпри заполнении не использовать пробелы.");

            while (check == false)
            {
                Console.Write("Введите Фамилию*: ");
                Surname = Console.ReadLine();
                if (Surname != null)
                {
                    try
                    {
                        Surname = Convert.ToString(Surname);
                        bool b = Exlusions.Any(Surname.Contains);
                        if (Surname == "")
                        {
                            Console.Clear();
                            Console.WriteLine("Поле почему-то осталось пустым! Попробуйте ещё раз!");
                            continue;
                        }
                        if (b == false)
                        {
                            check = true;
                            break;
                        }
                        else if (b == true)
                        {
                            Console.Clear();
                            Console.WriteLine("Введено не только буквы...Введите ещё раз!");
                        }

                    }
                    catch (Exception b)
                    {
                        Console.Clear();
                        Console.WriteLine("Введено не только буквы...Введите ещё раз!");
                    }
                }
                else if (Surname == null)
                {
                    Console.WriteLine("Поле почему-то осталось пустым! Попробуйте ещё раз!");
                    continue;
                }

            }
            check = false;

            while (check == false)
            {
                Console.Write("Введите Имя*: ");
                Name = Console.ReadLine();
                if (Name != null)
                {
                    try
                    {
                        bool b = Exlusions.Any(Name.Contains);
                        if (Name == "")
                        {
                            Console.Clear();
                            Console.WriteLine("Поле почему-то осталось пустым! Попробуйте ещё раз!");
                            continue;
                        }
                        if (b == false)
                        {
                            check = true;
                            break;
                        }
                        else if (b == true)
                        {
                            Console.Clear();
                            Console.WriteLine("Введено не только буквы...Введите ещё раз!");
                        }

                    }
                    catch (Exception b)
                    {
                        Console.Clear();
                        Console.WriteLine("Введено не только буквы...Введите ещё раз!");
                    }

                }
                else if (Name == null)
                {
                    Console.WriteLine("Поле почему-то осталось пустым! Попробуйте ещё раз!");
                    continue;
                }
            }
            check = false;

            while (check == false)
            {
                Console.Write("Введите Отчество(если есть или оставьте поле пустым): ");
                Patronymic = Console.ReadLine();
                if (Patronymic != "")
                {
                    try
                    {
                        bool b = Exlusions.Any(Patronymic.Contains);
                        if (b == false)
                        {
                            check = true;
                            break;
                        }
                        else if (b == true)
                        {
                            Console.Clear();
                            Console.WriteLine("Введено не только буквы...Введите ещё раз!");
                        }
                    }
                    catch (Exception b)
                    {
                        Console.Clear();
                        Console.WriteLine("Введено не только буквы...Введите ещё раз!");
                    }
                }
                else
                {
                    Patronymic = "пустое поле ";
                    check = true;
                }
            }
            check = false;

            while (check == false)
            {
                try
                {
                    Console.Write("Введите Номер телефона(только цифры, без знаков и пробелов)*: +79");
                    NumberOfPhone = Convert.ToInt32(Console.ReadLine());
                    check = true;
                }
                catch
                {
                    Console.Clear();
                    Console.WriteLine("Введено не только цифры...Введите ещё раз!");
                }

            }
            check = false;

            while (check == false)
            {
                try
                {
                    Console.Write("Введите Страну*: ");
                    Country = Console.ReadLine();
                    bool b = Exlusions.Any(Country.Contains);
                    if (Country == "")
                    {
                        Console.Clear();
                        Console.WriteLine("Поле почему-то осталось пустым! Попробуйте ещё раз!");
                        continue;
                    }
                    if (b == false)
                    {
                        check = true;
                        break;
                    }
                    else if (b == true)
                    {
                        Console.Clear();
                        Console.WriteLine("Введено не только буквы...Введите ещё раз!");
                    }

                }
                catch (Exception b)
                {
                    Console.Clear();
                    Console.WriteLine("Введено не только буквы...Введите ещё раз!");
                }
            }
            check = false;

            while (check == false)
            {
                Console.Write("Введите Дату рождения(или оставьте поле пустым): ");
                DayOfBirthday = Console.ReadLine();
                if (DayOfBirthday != "")
                {
                    if (DayOfBirthday.Count() == 10)
                    {
                        try
                        {
                            for (int i = 0; i < DayOfBirthday.Count(); i++)
                            {
                                if (i == 2 || i == 5)
                                    continue;
                                Convert.ToInt32(DayOfBirthday[i]);
                            }
                            if (DayOfBirthday[2] != '.' && DayOfBirthday[5] != '.')
                            {
                                Console.Clear();
                                Console.WriteLine("Дата указана неверено...Введите ещё раз!");
                                continue;
                            }
                        }
                        catch
                        {
                            Console.WriteLine("Дата указана неверено...Введите ещё раз!");
                        }
                    }
                    else if (DayOfBirthday != "" && DayOfBirthday.Count() != 10)
                    {
                        Console.Clear();
                        Console.WriteLine("Дата указана неверено...Введите ещё раз!");
                        continue;
                    }

                    check = true;
                    continue;
                }
                else
                {
                    DayOfBirthday = "пустое поле ";
                    check = true;
                }
            }
            check = false;

            while (check == false)
            {
                Console.Write("Введите Организацию(или оставьте поле пустым): ");
                Organization = Console.ReadLine();
                if (Organization != "")
                {
                    try
                    {
                        bool b = Exlusions.Any(Organization.Contains);
                        if (b == false)
                        {
                            check = true;
                            break;
                        }
                        else if (b == true)
                        {
                            Console.Clear();
                            Console.WriteLine("Введено не только буквы...Введите ещё раз!");
                        }
                    }
                    catch (Exception b)
                    {
                        Console.Clear();
                        Console.WriteLine("Введено не только буквы...Введите ещё раз!");
                    }
                }
                else
                {
                    Organization = "пустое поле ";
                    check = true;
                }
            }
            check = false;

            while (check == false)
            {
                Console.Write("Введите Должность(или оставьте поле пустым): ");
                Profession = Console.ReadLine();
                if (Profession != "")
                {
                    try
                    {
                        bool b = Exlusions.Any(Profession.Contains);
                        if (b == false)
                        {
                            check = true;
                            break;
                        }
                        else if (b == true)
                        {
                            Console.Clear();
                            Console.WriteLine("Введено не только буквы...Введите ещё раз!");
                        }
                    }
                    catch (Exception b)
                    {
                        Console.Clear();
                        Console.WriteLine("Введено не только буквы...Введите ещё раз!");
                    }
                }
                else
                {
                    Profession = "пустое поле ";
                    check = true;
                }
            }
            check = false;

            while (check == false)
            {
                Console.Write("Добавьте описание(или оставьте поле пустым): ");
                Description = Console.ReadLine();
                if (Description != "")
                {
                    check = true;
                }
                else
                {
                    Description = "пустое поле ";
                    check = true;
                }
            }
            check = false;


        }
        public void EditNote(int EditParamChoosen)
        {
            List<string> Exlusions = new List<string>();
            Exlusions.AddRange(new string[] {"1","2","3","4","5","6","7","8","9","0","!","@","#","$","%","^",
            "&","*","(",")","<",">",",",".","?","/","}","{","]","[","|","~",":",";","№", " "});
            bool EditEnable = false;
            bool check = false;
            while (EditEnable == false)
            {
                switch (EditParamChoosen)
                {
                    case 1:
                        {
                            Console.Clear();
                            Console.WriteLine($"Фамилия: {Surname}");
                            while (check == false)
                            {
                                Console.Write("Введите новую фамилию -");
                                Surname = Console.ReadLine();
                                if (Surname != "")
                                {
                                    try
                                    {
                                        Surname = Convert.ToString(Surname);
                                        bool b = Exlusions.Any(Surname.Contains);
                                        if (Surname == "")
                                        {
                                            Console.Clear();
                                            Console.WriteLine("Поле почему-то осталось пустым! Попробуйте ещё раз!");
                                            continue;
                                        }
                                        if (b == false)
                                        {
                                            check = true;
                                            break;
                                        }
                                        else if (b == true)
                                        {
                                            Console.Clear();
                                            Console.WriteLine("Введено не только буквы...Введите ещё раз!");
                                        }

                                    }
                                    catch (Exception b)
                                    {
                                        Console.Clear();
                                        Console.WriteLine("Введено не только буквы...Введите ещё раз!");
                                    }
                                }
                                else
                                {
                                    Console.WriteLine("Поле почему-то осталось пустым! Попробуйте ещё раз!");
                                    continue;
                                }

                            }
                            check = false;
                        }

                        break;

                    case 2:
                        {
                            Console.Clear();
                            Console.WriteLine($"Имя: {Name}");

                            while (check == false)
                            {
                                Console.Write("Введите новое имя -");
                                Name = Console.ReadLine();
                                if (Name != "")
                                {
                                    try
                                    {
                                        Name = Convert.ToString(Name);
                                        bool b = Exlusions.Any(Name.Contains);
                                        if (Name == "")
                                        {
                                            Console.Clear();
                                            Console.WriteLine("Поле почему-то осталось пустым! Попробуйте ещё раз!");
                                            continue;
                                        }
                                        if (b == false)
                                        {
                                            check = true;
                                            break;
                                        }
                                        else if (b == true)
                                        {
                                            Console.Clear();
                                            Console.WriteLine("Введено не только буквы...Введите ещё раз!");
                                        }

                                    }
                                    catch (Exception b)
                                    {
                                        Console.Clear();
                                        Console.WriteLine("Введено не только буквы...Введите ещё раз!");
                                    }
                                }
                                else
                                {
                                    Console.WriteLine("Поле почему-то осталось пустым! Попробуйте ещё раз!");
                                    continue;
                                }

                            }
                            check = false;

                            break;
                        }
                    case 3:
                        {
                            Console.Clear();
                            Console.WriteLine($"Отчество: {Patronymic}");
                            while (check == false)
                            {
                                Console.Write("Введите новое отчество -");
                                Patronymic = Console.ReadLine();
                                if (Patronymic != "")
                                {
                                    try
                                    {
                                        Patronymic = Convert.ToString(Patronymic);
                                        bool b = Exlusions.Any(Patronymic.Contains);
                                        if (Patronymic == "")
                                        {
                                            Console.Clear();
                                            Console.WriteLine("Поле почему-то осталось пустым! Попробуйте ещё раз!");
                                            continue;
                                        }
                                        if (b == false)
                                        {
                                            check = true;
                                            break;
                                        }
                                        else if (b == true)
                                        {
                                            Console.Clear();
                                            Console.WriteLine("Введено не только буквы...Введите ещё раз!");
                                        }

                                    }
                                    catch (Exception b)
                                    {
                                        Console.Clear();
                                        Console.WriteLine("Введено не только буквы...Введите ещё раз!");
                                    }
                                }
                                else if (Patronymic == null)
                                {
                                    Console.WriteLine("Поле почему-то осталось пустым! Попробуйте ещё раз!");
                                    continue;
                                }

                            }
                            check = false;
                            break;
                        }
                    case 4:
                        {
                            Console.Clear();
                            Console.WriteLine($"Номер телефона: {NumberOfPhone}");

                            while (check == false)
                            {
                                try
                                {
                                    Console.Write("Введите новый номер телефона(только цифры, без знаков и пробелов)*: +79");
                                    NumberOfPhone = Convert.ToInt32(Console.ReadLine());
                                    check = true;
                                }
                                catch
                                {
                                    Console.Clear();
                                    Console.WriteLine("Введено не только цифры...Введите ещё раз!");
                                }

                            }
                            check = false;

                            break;
                        }
                    case 5:
                        {
                            Console.Clear();
                            Console.WriteLine($"Страна: {Country}");

                            while (check == false)
                            {
                                Console.Write("Введите новую страну -");
                                Country = Console.ReadLine();
                                if (Country != "")
                                {
                                    try
                                    {
                                        Country = Convert.ToString(Country);
                                        bool b = Exlusions.Any(Country.Contains);
                                        if (Country == "")
                                        {
                                            Console.Clear();
                                            Console.WriteLine("Поле почему-то осталось пустым! Попробуйте ещё раз!");
                                            continue;
                                        }
                                        if (b == false)
                                        {
                                            check = true;
                                            break;
                                        }
                                        else if (b == true)
                                        {
                                            Console.Clear();
                                            Console.WriteLine("Введено не только буквы...Введите ещё раз!");
                                        }

                                    }
                                    catch (Exception b)
                                    {
                                        Console.Clear();
                                        Console.WriteLine("Введено не только буквы...Введите ещё раз!");
                                    }
                                }
                                else if (Country == null)
                                {
                                    Console.WriteLine("Поле почему-то осталось пустым! Попробуйте ещё раз!");
                                    continue;
                                }

                            }

                            break;
                        }
                    case 6:
                        {
                            Console.Clear();
                            Console.WriteLine($"День рождения: {DayOfBirthday}");

                            while (check == false)
                            {
                                Console.Write("Введите новую Дату рождения - ");
                                DayOfBirthday = Console.ReadLine();
                                if (DayOfBirthday != "")
                                {
                                    if (DayOfBirthday.Count() == 10)
                                    {
                                        try
                                        {
                                            for (int i = 0; i < DayOfBirthday.Count(); i++)
                                            {
                                                if (i == 2 || i == 5)
                                                    continue;
                                                Convert.ToInt32(DayOfBirthday[i]);
                                            }
                                            if (DayOfBirthday[2] != '.' && DayOfBirthday[5] != '.')
                                            {
                                                Console.Clear();
                                                Console.WriteLine("Дата указана неверено...Введите ещё раз!");
                                                continue;
                                            }
                                        }
                                        catch
                                        {
                                            Console.WriteLine("Дата указана неверено...Введите ещё раз!");
                                        }
                                    }
                                    else if (DayOfBirthday != "" && DayOfBirthday.Count() != 10)
                                    {
                                        Console.Clear();
                                        Console.WriteLine("Дата указана неверено...Введите ещё раз!");
                                        continue;
                                    }

                                    check = true;
                                    continue;
                                }
                                else
                                {
                                    DayOfBirthday = "пустое поле ";
                                    check = true;
                                }
                            }
                            check = false;

                            break;
                        }
                    case 7:
                        {
                            Console.Clear();
                            Console.WriteLine($"Организация: {Organization}");

                            while (check == false)
                            {
                                Console.Write("Введите новую организацию -");
                                Organization = Console.ReadLine();
                                if (Organization != "")
                                {
                                    try
                                    {
                                        Organization = Convert.ToString(Organization);
                                        bool b = Exlusions.Any(Organization.Contains);
                                        if (Organization == "")
                                        {
                                            Console.Clear();
                                            Console.WriteLine("Поле почему-то осталось пустым! Попробуйте ещё раз!");
                                            continue;
                                        }
                                        if (b == false)
                                        {
                                            check = true;
                                            break;
                                        }
                                        else if (b == true)
                                        {
                                            Console.Clear();
                                            Console.WriteLine("Введено не только буквы...Введите ещё раз!");
                                        }

                                    }
                                    catch (Exception b)
                                    {
                                        Console.Clear();
                                        Console.WriteLine("Введено не только буквы...Введите ещё раз!");
                                    }
                                }
                                else if (Organization == null)
                                {
                                    Console.WriteLine("Поле почему-то осталось пустым! Попробуйте ещё раз!");
                                    continue;
                                }

                            }

                            break;
                        }
                    case 8:
                        {
                            Console.Clear();
                            Console.WriteLine($"Профессия: {Profession}");

                            while (check == false)
                            {
                                Console.Write("Введите новую профессию -");
                                Profession = Console.ReadLine();
                                if (Profession != "")
                                {
                                    try
                                    {
                                        Profession = Convert.ToString(Profession);
                                        bool b = Exlusions.Any(Profession.Contains);
                                        if (Profession == "")
                                        {
                                            Console.Clear();
                                            Console.WriteLine("Поле почему-то осталось пустым! Попробуйте ещё раз!");
                                            continue;
                                        }
                                        if (b == false)
                                        {
                                            check = true;
                                            break;
                                        }
                                        else if (b == true)
                                        {
                                            Console.Clear();
                                            Console.WriteLine("Введено не только буквы...Введите ещё раз!");
                                        }

                                    }
                                    catch (Exception b)
                                    {
                                        Console.Clear();
                                        Console.WriteLine("Введено не только буквы...Введите ещё раз!");
                                    }
                                }
                                else if (Profession == null)
                                {
                                    Console.WriteLine("Поле почему-то осталось пустым! Попробуйте ещё раз!");
                                    continue;
                                }

                            }

                            break;
                        }
                    case 9:
                        {
                            Console.Clear();
                            Console.WriteLine($"Описание: {Description}");

                            while (check == false)
                            {
                                Console.Write("Добавьте описание(или оставьте поле пустым): ");
                                Description = Console.ReadLine();
                                if (Description != "")
                                {
                                    check = true;
                                }
                                else
                                {
                                    Description = "пустое поле ";
                                    check = true;
                                }
                            }
                            check = false;

                            break;
                        }

                }
            }
        }
        public void DeleteNote()
        {

        }
        public void ReadNote()
        {
            Console.WriteLine($"\nФамилия: {Surname}" +
                                $"\nИмя: {Name}" +
                                $"\nОтчество: {Patronymic}" +
                                $"\nНомер телефона: {NumberOfPhone}" +
                                $"\nСтрана: {Country}" +
                                $"\nДень рождения: {DayOfBirthday}" +
                                $"\nОрганизация: {Organization}" +
                                $"\nПрофессия: {Profession}" +
                                $"\nОписание: {Description}");
        }
        public void ShowAllNotes()
        {
            Console.WriteLine($"\nФамилия: {Surname}" +
             $"\nИмя: {Name}" +
            $"\nНомер телефона: {NumberOfPhone}");
        }
    }
}