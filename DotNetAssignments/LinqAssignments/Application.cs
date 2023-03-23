namespace LinqAssignments
{
    public class Application
    {
        public static void Start(string[] args)
        {
            Country country = new Country();
            State state = new State();
            District district = new District();
            Data data = new Data();

            //Console.WriteLine("====1st Add a new Country called "MyOwn"====");
            data.Countries.Add(new Country()
            {
                Id = 21,
                CountryName = "MyOwn"
            });


            //Console.WriteLine("====2nd Add a range of 10 states (State1, State2, etc...)to MyOwn country with each state having 10 districts (like, State1District1, State1District2, etc...) with random population====");

            Console.WriteLine("====3rd Get all countries and print them====");
            data.Countries.ForEach(c => Console.WriteLine(c.CountryName));


            Console.WriteLine("\n====4th Get all states of the countries and print them====");
            var stateWithCountry = from c in data.Countries
                                   join s in data.States on c.Id equals s.CountryId
                                   select new
                                   {
                                       CountryName = c.CountryName,
                                       StateName = s.StateName,
                                   };
            foreach (var item in stateWithCountry)
            {
                Console.WriteLine($"{item.CountryName}======>{item.StateName}");
            }


            Console.WriteLine("\n====5th Get all districts of the states of countries and print them====");
            var districtWithStateAndCountry = from c in data.Countries
                                              join s in data.States on c.Id equals s.CountryId
                                              join d in data.Districts on s.StateId equals d.StateId
                                              select new
                                              {
                                                  CountryName = c.CountryName,
                                                  StateName = s.StateName,
                                                  DistrictName = d.DistrictName,
                                              };
            foreach (var item in districtWithStateAndCountry)
            {
                Console.WriteLine($"{item.CountryName}===={item.StateName}===={item.DistrictName}");
            }


            Console.WriteLine("\n====6th Get states with whole population in a state====");
            var populationOfState = from s in data.States
                                    join d in data.Districts on s.StateId equals d.StateId
                                    group new { s, d } by new
                                    {
                                        StateName = s.StateName
                                    } into Result
                                    select new
                                    {
                                        StateName = Result.Key.StateName,
                                        Population = Result.Sum(p => p.d.Population)
                                    };
            foreach (var item in populationOfState)
            {
                Console.WriteLine($"Total population of {item.StateName} is:{item.Population}");
            }


            Console.WriteLine("\n====7th Get countries with whole population in a country====");
            var populationOfCountry = from c in data.Countries
                                      join s in data.States on c.Id equals s.CountryId
                                      join d in data.Districts on s.StateId equals d.StateId
                                      group new { s, d } by new
                                      {
                                          CountryName = c.CountryName
                                      } into Result
                                      select new
                                      {
                                          CountryName = Result.Key.CountryName,
                                          Population = Result.Sum(p => p.d.Population)
                                      };
            foreach (var item in populationOfCountry)
            {
                Console.WriteLine($"Total population of {item.CountryName} is:{item.Population}");
            }


            Console.WriteLine("\n====8th Get Top 5 most populated districts across states and countries====");
            var populatedDistrict = from s in data.States
                                    join d in data.Districts on s.StateId equals d.StateId
                                    orderby d.Population descending
                                    select d;
            foreach (var item in populatedDistrict.Take(5))
            {
                Console.WriteLine($"{item.StateId}===={item.DistrictName}===={item.Population}");
            }


            Console.WriteLine("\n====9th Get Top 2 most populated districts in every state of the countries====");
            var populatedDistrictOfState = from d in data.Districts
                                           group d by new
                                           {
                                               d.StateId
                                           };
            foreach (var item in populatedDistrictOfState)
            {
                Console.WriteLine(item.Key);
                foreach (var items in item.OrderByDescending(d => d.Population).Take(2))
                {
                    Console.WriteLine($"{items.StateId}---------{items.DistrictName}--------{items.Population}");
                }
            }


            Console.WriteLine("\n====10th Get Top one most populated country====");
            var populatedCountry = from c in data.Countries
                                   join s in data.States on c.Id equals s.CountryId
                                   join d in data.Districts on s.StateId equals d.StateId
                                   orderby d.Population descending
                                   select c.CountryName;
            Console.Write("The most populated Country among all the countries is:");
            Console.WriteLine(populatedCountry.FirstOrDefault());


            Console.WriteLine("\n====11th Get first country whose Name contains at least two vowels====");
            char[] vowel = { 'A', 'E', 'I', 'O', 'U' };
            var CountryContainVowel = data.Countries.FirstOrDefault(c => c.CountryName.ToUpper().Count(c => vowel.Contains(c)) >= 2);
            Console.WriteLine(CountryContainVowel.CountryName);

            Console.WriteLine("\n====12th Get first country whose Name contains at least two vowels ordered by Name====");
            var CountryContainVowels = data.Countries.OrderBy(c => c.CountryName).FirstOrDefault(c => c.CountryName.ToUpper().Count(c => vowel.Contains(c)) >= 2);
            Console.WriteLine($"{CountryContainVowels.CountryName}");


            Console.WriteLine("\n====13th Get Countries with states count====");
            var countStateInCountry = from c in data.Countries
                                      join s in data.States on c.Id equals s.CountryId
                                      orderby s.CountryId
                                      group new { c, s } by new
                                      {
                                          CountryId = c.Id,
                                          CountryName = c.CountryName,
                                      } into Result
                                      select new
                                      {
                                          CountryName = Result.Key.CountryName,
                                          StateCount = Result.Count()
                                      };
            foreach (var item in countStateInCountry)
            {
                Console.WriteLine($"{item.CountryName}---------------------{item.StateCount}");
            }


            Console.WriteLine("\n====14th Get Countries and states with district count====");
            var countDistrictInState = from s in data.States
                                       join d in data.Districts on s.StateId equals d.StateId
                                       orderby s.CountryId
                                       group new { s, d } by new
                                       {
                                           CountryID = s.CountryId,
                                           StateName = s.StateName,
                                       } into Result
                                       select new
                                       {
                                           CountryID = Result.Key.CountryID,
                                           StateName = Result.Key.StateName,
                                           DistrictCount = Result.Count()
                                       };
            foreach (var item in countDistrictInState)
            {
                Console.WriteLine($"{item.CountryID}--------{item.StateName}-------------{item.DistrictCount}");
            }


            Console.WriteLine("\n====15th Check do we have any country with out states, if yes print them====");
            var countryWithoutState = from c in data.Countries
                                      join s in data.States on c.Id equals s.CountryId into grouping
                                      from g in grouping.DefaultIfEmpty()
                                      where g?.StateId == null
                                      select c;
            foreach (var item in countryWithoutState)
            {
                Console.WriteLine($"{item.Id}===={item.CountryName}");
            }


            Console.WriteLine("\n====16th Check do we have any states in any country with out districts, if yes print them====");
            var stateWithoutDistrict = from s in data.States
                                       join d in data.Districts on s.StateId equals d.StateId into grouping
                                       from g in grouping.DefaultIfEmpty()
                                       where g?.DistrictId == null
                                       select s;
            foreach (var item in stateWithoutDistrict)
            {
                Console.WriteLine($"{item.StateId}===={item.StateName}");
            }


            Console.WriteLine("\n====17th Check do we have any states having same population in all districts of it, if yes print them====");
            var stateWithSamePopulation = from s in data.States
                                          join d in data.Districts on s.StateId equals d.StateId into Grp
                                          from g in Grp.DefaultIfEmpty()
                                          group g by s.StateName into Grp1
                                          where Grp1.All(p => p?.Population == Grp1.First()?.Population)
                                          select Grp1;
            foreach (var item in stateWithSamePopulation)
            {
                Console.WriteLine(item.Key);
            }


            Console.WriteLine("\n====18th Check do we have any country with same number of districts in all states, if yes print them====");
            var c_WithSame_NumOfDist_InAllState = from c in data.Countries
                                                  join s in data.States on c.Id equals s.CountryId
                                                  join d in data.Districts on s.StateId equals d.StateId
                                                  into e                                                  
                                                  group e by new
                                                  {
                                                      CName = c.CountryName,
                                                      SName = s.StateName,
                                                      DCount = e.Count()
                                                  }
                                                  into Grp2
                                                  group Grp2 by Grp2.Key.CName;
            foreach (var item in c_WithSame_NumOfDist_InAllState)
            {
                var firstCount = item.FirstOrDefault()?.Key?.DCount ?? 0;
                if (item.All(x => x.Key.DCount == firstCount))
                {
                    Console.WriteLine(item.Key);
                }
            }


            Console.WriteLine("\n====19th Get all districts whose population is greater than 500====");
            var districtPopulation = data.Districts.Where(d => d.Population > 500).OrderBy(x => x.DistrictName).ToList();
            districtPopulation.ForEach(c => Console.WriteLine(c.DistrictName));


            Console.WriteLine("\n====20th Get all states which has more than 5 districts====");
            var stateWithMoreThan5Districts = from s in data.States
                                              join d in data.Districts on s.StateId equals d.StateId
                                              into GroupofDistricts
                                              from g in GroupofDistricts.DefaultIfEmpty()
                                              group g by new { s.StateName } into g2
                                              where g2.Count() > 5
                                              select g2;
            foreach (var item in stateWithMoreThan5Districts)
            {
                Console.WriteLine($"{item.Key.StateName}");
            }


            Console.WriteLine("\n====21st Get all countries which has less than 5 states====");
            var countriesWithLessThan5States = from c in data.Countries
                                               join s in data.States on c.Id equals s.CountryId
                                               into GroupOfStates
                                               from g in GroupOfStates.DefaultIfEmpty()
                                               group g by new { c.CountryName } into g2
                                               where g2.Count() < 5
                                               select g2;

            countriesWithLessThan5States.ToList().ForEach(x => Console.WriteLine(x.Key.CountryName));


            //Console.WriteLine("====22nd Remove MyOwn Country====");
            var removeMyOwnCountry = data.Countries.FirstOrDefault(c => c.CountryName == "MyOwn");
            if (removeMyOwnCountry != null)
            {
                data.Countries.Remove(removeMyOwnCountry);
            }


            Console.WriteLine("\n====23rd Get single country with Name 'INDIA', if we have multiple throw error====");
            try
            {
                var getCountryIndia = data.Countries.Single(c => c.CountryName == "INDIA");
                Console.WriteLine(getCountryIndia.CountryName);
            }
            catch (Exception)
            {
                Console.WriteLine("There are more than one country having name as INDIA");
            }


            Console.WriteLine("\n====24th Get paginated country names by giving page number and page size, for example====");
            int pageNumber = 1;
            int pageSize = 5;
            var paginatedCountry = from c in data.Countries.Skip(pageSize * (pageNumber - 1)).Take(pageSize)
                                   select c.CountryName;
            paginatedCountry.ToList().ForEach(c => Console.WriteLine(c));
        }
    }
}