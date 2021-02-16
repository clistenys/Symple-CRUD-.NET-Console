using System;
using CRUD.Classes;
using CRUD.Interfaces;

namespace CRUD
{
    class Program
    {
        
        private static SerieRepositorio repository = new SerieRepositorio();
        static void Main(string[] args)
        {
            string userOption;
            userOption = ReadUserOption().ToUpper();

            while (userOption.ToUpper() != "X")
            {
                Console.Clear();

                switch (userOption)
				{
					case "1":
						ListSeries();
						break;
					case "2":
						CreateSerie();
						break;
					case "3":
						UpdadeSerie();
						break;
					case "4":
						DeleteSerie();
						break;
					case "5":
						ViewSerie();
						break;

					default:
						throw new ArgumentOutOfRangeException();
				}

                userOption = ReadUserOption().ToUpper();
            }

            Console.WriteLine("Thank you very much for your preference! Aways come back!");
        }

        private static string ReadUserOption()
        {
            Console.WriteLine();
			Console.WriteLine("CRUDFLIX");
			Console.WriteLine("Informe a opção desejada:");

			Console.WriteLine("1 - List Series;");
			Console.WriteLine("2 - Add Serie;");
			Console.WriteLine("3 - Update Serie;");
			Console.WriteLine("4 - Delete Series;");
			Console.WriteLine("5 - View serie;");
			
            Console.WriteLine();
            Console.WriteLine("X - Exit.");
			Console.WriteLine();

			string option = Console.ReadLine().ToUpper();
			Console.WriteLine();
			return option;
        }

        private static void DeleteSerie()
        {
            Console.WriteLine("Write the serie ID: ");
            int serieId = int.Parse(Console.ReadLine());

            repository.Delete(serieId);
        }

        private static void ViewSerie()
        {
            Console.WriteLine("Write the serie ID: ");
            int serieId = int.Parse(Console.ReadLine());

            var serie = repository.Read(serieId);

            Console.WriteLine(serie);
        }

        private static void UpdadeSerie()
        {
            Console.WriteLine("Write the serie ID: ");
            int serieId = int.Parse(Console.ReadLine());

            foreach(int index in Enum.GetValues(typeof(Gender)))
            {
                Console.WriteLine("{0}-{1}", index, Enum.GetName(typeof(Gender), index));
            }
            Console.Write("Type it the serie Gender from the options above: ");
            int newGender = int.Parse(Console.ReadLine());

            Console.Write("Type it the serie Tittle: ");
			string newTittle = Console.ReadLine();

			Console.Write("Type it the serie Start Year: ");
			int newYear = int.Parse(Console.ReadLine());

			Console.Write("Type it the serie Description: ");
			string newDescription = Console.ReadLine();

            Serie updatedSerie = new Serie( id: serieId,
                                            gender: (Gender)newGender,
                                            tittle: newTittle,
                                            year: newYear,
                                            description: newDescription);

            repository.Update(serieId, updatedSerie);
        }

        private static void ListSeries()
        {
            Console.WriteLine("Our Series List:");

            var seriesList = repository.ShowList();

            if(seriesList.Count == 0)
            {
                Console.WriteLine("The list is Empty!");
            }

            foreach (var serie in seriesList)
			{
                var excluido = serie.GetExcluded();
                
				Console.WriteLine("#ID {0}: - {1} {2}", serie.GetId(), serie.GetTittle(), (excluido ? "*Excluído*" : ""));
			}
        }
        private static void CreateSerie()
        {
            Console.WriteLine("Adding a new Serie!");
            foreach(int index in Enum.GetValues(typeof(Gender)))
            {
                Console.WriteLine("{0}-{1}", index, Enum.GetName(typeof(Gender), index));
            }
            Console.Write("Type it the serie Gender from the options above: ");
            int newGender = int.Parse(Console.ReadLine());

            Console.Write("Type it the serie Tittle: ");
			string newTittle = Console.ReadLine();

			Console.Write("Type it the serie Start Year: ");
			int newYear = int.Parse(Console.ReadLine());

			Console.Write("Type it the serie Description: ");
			string newDescription = Console.ReadLine();

            Serie newSerie = new Serie( id: repository.NextId(),
                                            gender: (Gender)newGender,
                                            tittle: newTittle,
                                            year: newYear,
                                            description: newDescription);

            repository.Create(newSerie);
        }
    }
}
