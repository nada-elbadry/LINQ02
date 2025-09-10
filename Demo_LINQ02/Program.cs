namespace Demo_LINQ02
{
    internal class Program
    {
        static void Main(string[] args)
        {
            static IEnumerable<int> GetLazyNumbers()
            {
                for (int i = 1; i <= 10; i++)
                {
                    yield return i;
                }
            }
            static void Main(string[] args)
            {
                #region Overview On Linq

                //List<int> Numbers = new List<int>(10) { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };

                ////        // 1. Fluent Syntax - Method Syntax 
                //////        // 1.1 Call Linq Operators As object Member Method [Extension Method]
                //var EvenNumbers = Numbers.Where(X => X % 2 == 0).ToList();

                //Numbers.AddRange(11, 12, 13, 14, 15);

                //foreach (int num in EvenNumbers)
                //	Console.WriteLine(num); // 2 4 6 8 10  


                //////							//        // 1.2 Call Linq Operators As Class Member Method 
                ////EvenNumbers = Enumerable.Where(Numbers, X => X % 2 == 0);



                // 2. Query Syntax
                // Statred With From And Must Ended With "Select" Or "GroupBy" 

                /* Select *
                          * From Numbers N
                          * Where N % 2 == 0 */


                //EvenNumbers = from N in Numbers
                //			  where N % 2 == 0
                //			  select N;

                #endregion

                #region Filtration (Restriction) Operators [Where , TypeOf]

                #region Where 
                //var Result = ProductList.Where(P => P.UnitsInStock > 0 && P.UnitPrice > 20.0M);

                //Result = from P in ProductList
                //		 where P.UnitsInStock > 0 && P.UnitPrice > 20.0M
                //		 select P;


                //var Result = ProductList.Where((P, I) => I < 10 && P.ProductName.Length <= 10);
                ////Search in the First 10 Elements only
                //// Get Products ProductName.Length <= 10 From First 10 Elements
                //// Indexed Where is Valid Only in Fluent Syntax, Can't Be Written Using Query Expression
                //foreach (var Item in Result)
                //	Console.WriteLine(Item);

                #endregion

                #region TypeOf 

                //var Result = ProductList.OfType<Product02>().Where(predicate: P=>P.UnitPrice <10);

                //foreach (var Item in Result)
                //	Console.WriteLine(Item);
                //////ProductID:2000,ProductName:Product02,Category,UnitPrice:100,UnitsInStock:0
                //////ProductID:3000,ProductName:Product03,Category,UnitPrice:60,UnitsInStock:0
                //////ProductID:4000,ProductName:Product04,Category,UnitPrice:70,UnitsInStock:0

                //ArrayList fruits = new()
                //		 {
                //			 "Mango",
                //			 "Orange",
                //			 null,
                //			 "Apple",
                //			 3.0,
                //			 "Banana",
                //	"LemoN"
                //};

                //var Result = fruits.OfType<string>().Where(S => S.Contains('n', StringComparison.CurrentCultureIgnoreCase));

                //foreach (var fruit in Result) 
                //	Console.WriteLine(fruit);
                //// Mango
                //// Orange
                //// Banana
                //// LemoN



                #endregion

                #endregion

                #region Transformation (Projection) Operators [Select , Select Many , Zip]

                #region Select

                //var ProductNames = ProductList.Select(P => P.ProductName);

                //ProductNames = from P in ProductList
                //			   select P.ProductName;

                //var Result01 = ProductList.Select(P => new Product() { ProductID = P.ProductID, ProductName = P.ProductName });
                //// Rest Of Properties = Null

                //var Result02 = ProductList.Select(P => new { P.ProductID, ProductName = P.ProductName });
                //// Object From Ananymous Type
                ////CLR Will Create Class In Runtime and Override To String


                //Result02 = from P in ProductList
                //		   select new
                //		   {
                //			   ProductID = P.ProductID,
                //			   ProductName = P.ProductName
                //		   };


                //var DiscountedList = ProductList.Where(P => P.UnitsInStock > 0)
                //								.Select(P => new
                //								{
                //									Id = P.ProductID,
                //									Name = P.ProductName,
                //									NewPrice = P.UnitPrice - (P.UnitPrice * 0.1M)
                //								});

                //DiscountedList = from P in ProductList
                //				 where P.UnitsInStock > 0
                //				 select new
                //				 {
                //					 Id = P.ProductID,
                //					 Name = P.ProductName,
                //					 NewPrice = P.UnitPrice - (P.UnitPrice * 0.1M)
                //				 };


                //var Result = ProductList.Where(P => P.UnitsInStock > 0)
                //						.Select((P, I) => new
                //						{
                //							Serial = I + 1,
                //							Name = P.ProductName
                //						});

                //foreach (var Item in Result)
                //	Console.WriteLine(Item);

                #endregion

                #region Select Many

                //List<string> phrases = ["Route Academy", "Backend .Net Track", "Linq Course"];

                //var query = from phrase in phrases
                //			from word in phrase.Split(' ')
                //			select word;

                //query = phrases.SelectMany(P => P.Split(' '));
                ////query = phrases.SelectMany(phrases => phrases.Split(' '));

                //foreach (string s in query)
                //{
                //	Console.WriteLine(s);
                //}


                ////// Orders => Array Of Order

                //var CustomerOrder = CustomerList.Select(C => C.Orders);
                ////Console.WriteLine(CustomerOrder); // Namespace.TypeName

                //var CustomerOrders = CustomerList.SelectMany(C => C.Orders);

                //CustomerOrders = from C in CustomerList
                //				 from O in C.Orders
                //				 select O;
                ////foreach (var CustomerOrder in CustomerOrders)
                ////	Console.WriteLine(CustomerOrder);
                ////// Order Id: 10643, Date: 8/25/1997, Total: 814.50
                ////// Order Id: 10692, Date: 10/3/1997, Total: 878.00
                ////// Order Id: 10702, Date: 10/13/1997, Total: 330.00
                ////// Order Id: 10835, Date: 1/15/1998, Total: 845.80


                //var CustomerOrders = CustomerList.SelectMany(C => C.Orders, (Customer, Order) => (Customer.CustomerName, Order.OrderID));

                //CustomerOrders = from C in CustomerList
                //				 from O in C.Orders
                //				 select (C.CustomerName, O.OrderID);

                //foreach (var CustomerOrder in CustomerOrders)
                //	Console.WriteLine(CustomerOrder);
                //////(Ahmed Ali, 10643) 
                //////(Ahmed Ali, 10692) 
                //////(Ahmed Ali, 10702) 
                //////(Ahmed Ali, 10835) 
                //////(Ahmed Ali, 10952) 
                //////(Ahmed Ali, 11011)


                //var CustomerOrders02 = CustomerList.SelectMany((C, Index) => C.Orders.Select((O, I) => new { CustomerIndex = Index, C.CustomerName, OrderIndex = I, OrderId = O.OrderID }));


                //var Result = CustomerList.SelectMany((C , CI) => C.Orders.Select((O , OI) => new {CustomerIndex = CI , CustomerName = C.CustomerName , }) )

                //foreach (var CustomerOrder in CustomerOrders02)
                //	Console.WriteLine(CustomerOrder);

                //// { CustomerIndex = 0, CustomerName = Ahmed Ali, OrderIndex = 0, OrderId = 10643 }
                //// { CustomerIndex = 0, CustomerName = Ahmed Ali, OrderIndex = 1, OrderId = 10692 }
                //// { CustomerIndex = 0, CustomerName = Ahmed Ali, OrderIndex = 2, OrderId = 10702 }
                //// { CustomerIndex = 0, CustomerName = Ahmed Ali, OrderIndex = 3, OrderId = 10835 }
                //// { CustomerIndex = 0, CustomerName = Ahmed Ali, OrderIndex = 4, OrderId = 10952 }
                //// { CustomerIndex = 0, CustomerName = Ahmed Ali, OrderIndex = 5, OrderId = 11011 }


                #endregion

                #region Zip 

                //List<int> numbers = [1, 2, 3, 4, 5, 6, 7];
                //char[] letters = ['A', 'B', 'C', 'D', 'E', 'F'];
                //string[] Words = ["First", "Second", "Third", "Fourth", "Fifth"];


                //var Result = numbers.Zip(letters, (N, L) => $"Number {N} is Zipped With Letter {L}");


                ////var Result = numbers.Zip(letters, (N, L) => $"Number {N} is Zipped With Letter {L}");

                //foreach (var item in Result)
                //	Console.WriteLine(item);
                //////// Number 1 is Zipped With Letter A
                //////// Number 2 is Zipped With Letter B
                //////// Number 3 is Zipped With Letter C
                //////// Number 4 is Zipped With Letter D
                //////// Number 5 is Zipped With Letter E
                //////// Number 6 is Zipped With Letter F


                #endregion

                #endregion

                #region Ordering Operators


                //var Result = ProductList.OrderByDescending()


                ////foreach (var item in Result)
                ////	Console.WriteLine(item);

                //Result = CustomerList.OrderBy(C => C.CustomerName)

                //Result = from C in CustomerList
                //		 orderby C.CustomerName descending
                //		 select C;

                // Result = ProductList.OrderByDescending(p => p.UnitsInStock).ThenBy(P => P.UnitPrice);

                //Result = from p in ProductList
                //		 orderby p.UnitsInStock , p.UnitPrice descending
                //		 select p;




                //var Result01 = CustomerList.Where(C => C.CustomerName.Length < 15).Select(C => C.CustomerName).Reverse();




                //foreach (var item in Result01)
                //	Console.WriteLine(item);



                //var Result02 = CustomerList.Where(C => C.CustomerName.Length < 15).Select(C => C.CustomerName).OrderBy(S => S.Length);

                //foreach (var item in Result02)
                //	Console.WriteLine(item);


                #endregion

                #region Element Operators - [Valid Only With Fluent Syntax]
                //var Result = ProductList.First()
                //Result = ProductList.Last();

                //List<Product> TestProduct = new List<Product>();
                ////var Result = TestProduct.First();
                ////Console.WriteLine(Result); // Sequence contains no elements
                ////						   //// First and Last Will Throw Exception if The Sequence is Empty or Null

                //var Result = TestProduct.FirstOrDefault();
                //Console.WriteLine(Result);



                ////Result = TestProduct.LastOrDefault(new Product() { ProductID = 10, ProductName = "Test" });
                ////// ProductID:10,ProductName:Test,Category,UnitPrice:0,UnitsInStock:0
                //////FirstOrDefault and LastOrDefault  If Sequence is Empty => Return Default
                ////Result = ProductList.First(P => P.UnitsInStock == 0); // Return First Element That Match Condition
                //////if There is no Matching in Sequence  => "Sequence contains no matching element" Exception Thrown
                ////Result = ProductList.FirstOrDefault(P => P.UnitPrice > 1000);
                //////if There is no Matching in Sequence  => Return Default
                /////




                //var Result = ProductList.ElementAtOrDefault() // ProductID:2,ProductName:Chang,CategoryBeverages,UnitPrice:19.0000,UnitsInStock:17
                //								   //Result = ProductList.ElementAt(new Index(1 ,true)); // ProductID:77,ProductName:Original Frankfurter grüne Soße,CategoryCondiments,UnitPrice:13.0000,UnitsInStock:32
                //								   //Result = ProductList.ElementAt(^1); // Syntax Sugar
                //								   //Result = ProductList.ElementAt(1000); // 'Index was out of range' Exception Thrown
                //								   //Result = ProductList.ElementAtOrDefault(1000); // If Index was out of range => Return Default






                //var Result = ProductList.Single(P => P.ProductID == 1);



                ////// If Sequence Conatins Just Only One Element => Will Return it
                //// Else Will Throw Exception (Sequence is Empty or Containts More than One Element)
                //Result = ProductList.SingleOrDefault();
                //Result = ProductList.Single(P => P.UnitPrice > 4);// Throw Exception
                //var Result = ProductList.SingleOrDefault(P => P.UnitPrice > 4);
                /////If Sequence Conatins No Element Matching Condition, Will Return Null
                /////If Sequence Conatins Just Only One Element Matching Condition, Will Return it
                ///// If Sequence Conatins More than One Element Matching Condition, Will Throw Exception


                //var Result02 = (from P in ProductList
                //				where P.UnitsInStock == 0
                //				select new
                //				{
                //					P.ProductID,
                //					P.ProductName,
                //					P.UnitsInStock
                //				}).FirstOrDefault();


                #endregion

                #region Aggregate Operators 

                #region Count and TryGetNonEnumeratedCount

                //var Result = ProductList.Count(); // LINQ Operator
                //Result = ProductList.Count; // List Property [Recommended]

                //var Numbers = Enumerable.Range(1, 100);
                //Console.WriteLine(Numbers.Count()); // 100

                //var NumbersList = Numbers.ToList();
                ////Console.WriteLine(NumbersList.Count()); // 100
                ////Console.WriteLine(NumbersList.Count); // 100

                //Result = ProductList.Count(P => P.UnitsInStock == 0);

                //////Result = ProductList.Count(P => P.UnitsInStock > 0);
                //////Console.WriteLine(Result); // 72

                //int Result;
                //bool Flag = ProductList.TryGetNonEnumeratedCount(out Result);
                //Console.WriteLine(Flag); // True 
                //Console.WriteLine(Result); // 77

                //Console.WriteLine("================================");
                //var LazyNumbers = GetLazyNumbers();

                // Result = LazyNumbers.Count(); // 10
                // Flag = LazyNumbers.TryGetNonEnumeratedCount(out Result);
                //Console.WriteLine(Flag); // True 
                //Console.WriteLine(Result); // 77
                //						   ////// Works best with IQueryable<T> or collections that can determine the count without iteration.
                //						   ////Console.WriteLine(Flag); // False 
                //						   ////Console.WriteLine(Result); // 0


                #endregion

                #region Sum And Average
                //var Result = ProductList.Sum(P => P.UnitPrice); // 2222.7100
                //Result = ProductList.Average(P => P.UnitPrice); // 28.83
                //Console.WriteLine(Result);
                #endregion

                #region Max and Min

                //var Result = ProductList.Max();
                ////// Product Must be Implement Interface "IComparable"
                //Console.WriteLine(Result); // ProductID:38,ProductName:Côte de Blaye,CategoryBeverages,UnitPrice:263.5000,UnitsInStock:17
                //////Result = ProductList.Min(); // 2.5
                ////Console.WriteLine(Result); // ProductID:33,ProductName:Geitost,CategoryDairy Products,UnitPrice:2.5000,UnitsInStock:112

                //Result = ProductList.Max(new ProductUnitInStockComparer());
                //Console.WriteLine(Result); //ProductID:75,ProductName:Rhönbräu Klosterbier,CategoryBeverages,UnitPrice:7.7500,UnitsInStock:125


                ////Console.WriteLine(MinLengthProductName);


                //var Result = from P in ProductList
                //			 where P.ProductName == MinProductName
                //			 select P;
                //////Console.WriteLine(Result); // ProductID:17,ProductName:Alice Mutton,CategoryMeat/Poultry,UnitPrice:39.0000,UnitsInStock:0


                //var MinProductName = ProductList.Min(P => P.ProductName);
                //var Result = ProductList.MinBy(P => P.ProductName);
                //Console.WriteLine(Result); // ProductID:17,ProductName:Alice Mutton,CategoryMeat/Poultry,UnitPrice:39.0000,UnitsInStock:0

                #endregion

                #region Aggregate

                //string[] Words = { "Hello", "From", "Route", "Academy" };
                //var Result = Words.Aggregate("Hi ", ((Str01, Str02) => $"{Str01} {Str02}") , Result => Result.Replace(' ' , '_'));
                //Console.WriteLine(Result); // Hello From Route Academy
                //						   //						   // Str01 = Hello , Str02 = From
                //						   //						   // Str01 = Hello From , Str02 = Route
                //						   //						   // Str01 = Hello From Route , Str02 = Academy
                //						   //						   // Result = Hello From Route Academy

                ////Result = Words.Aggregate("Hi : ", (Str01, Str02) => $"{Str01} {Str02}");
                ////Console.WriteLine(Result); // Hi :  Hello From Route Academy
                ////Result = Words.Aggregate("Hi : ", (Str01, Str02) => $"{Str01} {Str02}", (TAcc) => TAcc.Replace(' ', '_'));
                ////Console.WriteLine(Result); //Hi_:__Hello_From_Route_Academy

                #endregion

                #endregion

                #region Casting Operators 

                //List<Product> list = ProductList.Where(P => P.UnitsInStock == 0).ToList(); // Casting To List
                //Product[] array = ProductList.Where(P => P.UnitsInStock == 0).ToArray(); // Casting To Array
                //Dictionary<long, Product> Dic01 = ProductList.Where(P => P.UnitsInStock == 0) .ToDictionary(P => P.ProductID);
                ///// [5, ProductID:5,ProductName:Chef Anton's Gumbo Mix,CategoryCondiments,UnitPrice:21.3500,UnitsInStock:0]
                ///// [17, ProductID:17,ProductName:Alice Mutton,CategoryMeat/Poultry,UnitPrice:39.0000,UnitsInStock:0]
                ///// [29, ProductID:29,ProductName:Thüringer Rostbratwurst,CategoryMeat/Poultry,UnitPrice:123.7900,UnitsInStock:0]
                ///// [31, ProductID:31,ProductName:Gorgonzola Telino,CategoryDairy Products,UnitPrice:12.5000,UnitsInStock:0]
                ///// [53, ProductID:53,ProductName:Perth Pasties,CategoryMeat/Poultry,UnitPrice:32.8000,UnitsInStock:0]
                //Dictionary<long, string> Dic02 = ProductList.Where(P => P.UnitsInStock == 0).ToDictionary(P => P.ProductID, P => P.ProductName);
                ///// [5, Chef Anton's Gumbo Mix]
                ///// [17, Alice Mutton]
                ///// [29, Thüringer Rostbratwurst]
                ///// [31, Gorgonzola Telino]
                ///// [53, Perth Pasties]
                //HashSet<Product> Set = ProductList.Where(P => P.UnitsInStock == 0).ToHashSet();
                //Set.Add(new Product() { ProductName = "AddNewProduct" });
                ///// ProductID:5,ProductName:Chef Anton's Gumbo Mix,CategoryCondiments,UnitPrice:21.3500,UnitsInStock:0
                ///// ProductID:17,ProductName:Alice Mutton,CategoryMeat/Poultry,UnitPrice:39.0000,UnitsInStock:0
                ///// ProductID:29,ProductName:Thüringer Rostbratwurst,CategoryMeat/Poultry,UnitPrice:123.7900,UnitsInStock:0
                ///// ProductID:31,ProductName:Gorgonzola Telino,CategoryDairy Products,UnitPrice:12.5000,UnitsInStock:0
                ///// ProductID:53,ProductName:Perth Pasties,CategoryMeat/Poultry,UnitPrice:32.8000,UnitsInStock:0
                ///// ProductID:0,ProductName:AddNewProduct,Category,UnitPrice:0,UnitsInStock:0

                //var SortedCollection = ProductList.Where(P => P.UnitsInStock == 0).ToImmutableHashSet();
                //SortedCollection.Add(new Product() { ProductName = "AddNewProduct" });
                ///// ProductID:53,ProductName:Perth Pasties,CategoryMeat/Poultry,UnitPrice:32.8000,UnitsInStock:0
                ///// ProductID:5,ProductName:Chef Anton's Gumbo Mix,CategoryCondiments,UnitPrice:21.3500,UnitsInStock:0
                ///// ProductID:17,ProductName:Alice Mutton,CategoryMeat/Poultry,UnitPrice:39.0000,UnitsInStock:0
                ///// ProductID:29,ProductName:Thüringer Rostbratwurst,CategoryMeat/Poultry,UnitPrice:123.7900,UnitsInStock:0
                ///// ProductID:31,ProductName:Gorgonzola Telino,CategoryDairy Products,UnitPrice:12.5000,UnitsInStock:0
                #endregion

                #region Generation Operators 
                //// Valid With Fluent Syntax Only
                //// The Only Way To Call Them is As Static Methods from Enumerable  Class

                //var Result = Enumerable.Range(1, 1000);// 1..1000

                //Result = Enumerable.Repeat(2, 100); // Return IEnumerable of 100 Element each one value = 2 
                //var products = Enumerable.Repeat(new Product() { Category = "Meat"}, 100); //// Return IEnumerable of 100 Product

                //var ArrayResult = Enumerable.Empty<Product>().ToArray(); //Return Empty  Array<product>
                //Product[] Arr = new Product[0];
                //// both Will Generate an Empty Array of Product

                //var ListResult = Enumerable.Empty<Product>().ToList();
                //List<Product> List = new List<Product>();
                //// both Will Generate an Empty List of Product

                #endregion

                #region Set Operators [Union Family] 

                //// Set Operators = > Union, UnionAll, Except, Intersect

                //var Seq01 = Enumerable.Range(0, 100);// 0..99
                //var Seq02 = Enumerable.Range(50, 100);//50..149

                //var Result = Seq01.Union(Seq02); // 0..149 => Remove Duplication
                //Result = Seq01.Concat(Seq02); // 0..99 + 50..149 => Without Removing Duplication

                //Result = Result.Distinct(); // 0..149 => Remove Duplication
                //							// Concat + Distinct => Act as Union

                //Result = Seq01.Intersect(Seq02); // 50..99 
                //Result = Seq01.Except(Seq02); // 0..49




                //var Products01 = new List<Product>()
                //{
                //	new Product() {ProductID = 1, ProductName = "Chai", Category = "Beverages", UnitPrice = 18.00M, UnitsInStock = 100},
                //	new Product{ ProductID = 2, ProductName = "Chang", Category = "Beverages", UnitPrice = 19.0000M, UnitsInStock = 17 },
                //	new Product{ ProductID = 3, ProductName = "Aniseed Syrup", Category = "Condiments", UnitPrice = 10.0000M, UnitsInStock = 13 },
                //	new Product{ ProductID = 4, ProductName = "Chef Anton's Cajun Seasoning", Category = "Condiments", UnitPrice = 22.0000M, UnitsInStock = 53 }
                //};


                //var Products02 = new List<Product>()
                //{
                //	new Product{ ProductID = 1, ProductName = "Chai", Category = "Beverages", UnitPrice = 18.00M, UnitsInStock = 100},
                //	new Product{ ProductID = 2, ProductName = "Test", Category = "Beverages", UnitPrice = 19.0000M, UnitsInStock = 17 },
                //	new Product{ ProductID = 4, ProductName = "Test", Category = "Condiments", UnitPrice = 22.0000M, UnitsInStock = 53 },
                //	new Product{ ProductID = 6, ProductName = "Grandma's Boysenberry Spread", Category = "Condiments",UnitPrice = 25.0000M, UnitsInStock = 120 },
                //};


                //var Result = Products01.Union(Products02 , new ProductIdEquailtyComparer());
                //Result = Products01.UnionBy(Products02 , P=> P.ProductID);

                //Result = Products01.Intersect(Products02 , new ProductIdEquailtyComparer());
                //Result = Products01.IntersectBy(Products02.Select(P=>P.ProductID) , P=>P.ProductID);

                //Result = Products01.Except(Products02);
                //Result = Products01.Except(Products02, new ProductIdEquailtyComparer());
                //Result = Products01.ExceptBy(Products02.Select(P => P.ProductID), P => P.ProductID);

                //Result = Products01.Distinct();
                //Result = Products01.Distinct(new ProductIdEquailtyComparer());
                //Result = Products01.DistinctBy(P => P.ProductID);

                //foreach (var item in Result)
                //	Console.WriteLine(item);


                #endregion

                #region  Quantifier  Operator - Return boolean

                //Console.WriteLine(ProductList.Any()); //True
                //									  //If Sequence contains at least one Element Will Return True

                //Console.WriteLine(ProductList.Any(P => P.UnitsInStock == 0)); //True
                //															  //If Sequence contains at least one Element Match Condition Will Return True
                //Console.WriteLine(ProductList.Any(P => P.UnitPrice > 1000));// False

                //Console.WriteLine(ProductList.All(P => P.UnitsInStock == 0)); //False
                //															  //If All Elements in Sequence Match Condition Will Return True

                //var Products01 = new List<Product>()
                //{
                //	new Product{ ProductID = 1, ProductName = "Chai", Category = "Beverages", UnitPrice = 18.00M, UnitsInStock = 100},
                //	new Product{ ProductID = 2, ProductName = "Chang", Category = "Beverages", UnitPrice = 19.0000M, UnitsInStock = 17 },
                //	new Product{ ProductID = 3, ProductName = "Aniseed Syrup", Category = "Condiments", UnitPrice = 10.0000M, UnitsInStock = 13 },
                //	new Product{ ProductID = 4, ProductName = "Chef Anton's Cajun Seasoning", Category = "Condiments", UnitPrice = 22.0000M, UnitsInStock = 53 }
                //};

                //Product product = new Product { ProductID = 3, ProductName = "Syrup", Category = "Condiments", UnitPrice = 10.0000M, UnitsInStock = 13 };

                //Console.WriteLine(Products01.Contains<Product>(product)); // false
                //Console.WriteLine(Products01.Contains(product , new ProductIdEquailtyComparer())); // true

                //var Seq01 = Enumerable.Range(0, 100);// 0..99
                //var Seq02 = Enumerable.Range(50, 100);//50..149
                //Console.WriteLine(Seq01.SequenceEqual(Seq02)); // False
                //// If 2 Sequences are Equal Will Return True 

                #endregion

                #region Let and Into [Valid With Query Syntax Only]

                //var Result = from P in ProductList
                //			 where P.UnitPrice * 0.9M < 10
                //			 select new { P.ProductName, PriceAfterDis = P.UnitPrice * 0.9M };

                ////// let => Continue Query With Added A new Temp Variable 
                //Result = from P in ProductList
                //		 let DiscPrice = P.UnitPrice * 0.9M
                //		 where DiscPrice < 10
                //		 select new { P.ProductName, PriceAfterDis = DiscPrice };

                //// Into => Restart Query With Introducing A new Range Varaible 
                //// Used With group by 
                //var Result02 = from P in ProductList
                //			   select P.UnitPrice * 0.9M
                //		       into DiscPrice
                //			   where DiscPrice < 10
                //			   select DiscPrice;


                //foreach (var item in Result) 
                //	Console.WriteLine(item);

                #endregion

                #region Grouping Operators


                //// Query Syntax
                //var Result = from p in ProductList
                //			 where p.UnitsInStock != 0
                //			 group p by p.Category into Category
                //			 where Category.Count() > 10
                //			 select new
                //			 {
                //				 CategoryName = Category.Key,
                //				 Count = Category.Count()
                //			 };

                //foreach (var item in Result)
                //	Console.WriteLine(item);





                //foreach (var Category in Result)
                //{
                //	Console.WriteLine($"Category : {Category.Key}");
                //	foreach (var Product in Category)
                //		Console.WriteLine($"\t{Product}");

                //}


                // Method Syntax

                //var Result = ProductList.Where(P => P.UnitsInStock != 0)
                //					   .GroupBy(P => P.Category, P => P.ProductName, (cat, Products) => new { category = cat, Count = Products.Count() });


                //foreach (var item in Result)
                //	Console.WriteLine(item);



                //foreach (var Category in Result)
                //{
                //	Console.WriteLine($"Category : {Category.Key}");
                //	foreach (var Product in Category)
                //		Console.WriteLine($"\t{Product}");
                //}
                #endregion

                #region Partitioning Operators

                //var Result = ProductList.Where(P => P.UnitsInStock == 0).Take(5);
                //// Operator allows you to take a specified number of elements from the beginning of a collection.
                //Result = ProductList.Where(P => P.UnitsInStock == 0).TakeLast(5);
                //// Operator allows you to take the last n elements from a collection.
                //Result = ProductList.Where(P => P.UnitsInStock == 0).Skip(5);
                //// Operator allows you to skip a specified number of elements from the beginning of a collection and return the rest.
                //Result = ProductList.Where(P => P.UnitsInStock == 0).SkipLast(5);
                //// Operator allows you to skip a specified number of elements from the end of the collection.

                //int[] Numbers = { 5, 4, 1, 3, 9, 8, 6, 7, 2, 0 };

                //var Result02 = Numbers.TakeWhile((Num, i) => Num > i);// 5,4
                //													  // Operator allows you to take elements from the beginning of the collection as long as a condition is met.
                //Result02 = Numbers.SkipWhile(Num => Num % 3 != 0); // 3,9,8,6,7,2,0
                //												   // Operator allows you to skip elements from the collection as long as a condition is true. Once the condition becomes false, it will take the remaining elements

                //var Chucks = Numbers.Chunk(3);
                //// The Chunk operator is used to split elements of a sequence based on a given size.

                //int chunkNumber = 1;
                //foreach (var chunk in Chucks)
                //{
                //	Console.WriteLine($"Chunk {chunkNumber++}:");
                //	foreach (int item in chunk)
                //	{
                //		Console.WriteLine($"\t{item}");
                //	}
                //}

                //var Result03 = ProductList.Chunk(10);

                //foreach (var chunk in Result03)
                //	Console.WriteLine(chunk.Length);

                #endregion
            }
        }
    }
}
