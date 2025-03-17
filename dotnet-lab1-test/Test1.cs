using dotnet_lab1;
namespace dotnet_lab1_test
{
    [TestClass]
    public sealed class Test1
    {
        [TestMethod]
        public void TestMethodCountElements() // test, czy generowana jest odpowiednia ilość przedmiotów
        {
            List<int> sizes = new List<int>() { 10, 20, 30, 40, 50 };

            foreach (int n in sizes)
            {
                Problem problem = new Problem(1, n);
                Assert.AreEqual(n, problem.items.Count);
            }
        }

        [TestMethod]
        public void AtLeastOneReturned() // test, czy zwracany jest przynajmniej jeden przedmiot, jeśli zmieści się do plecaka
        {
            Problem problem = new Problem(1, 3); //wygenerowano 3 przedmiotów
            problem.items[0].Weight = 1; //pierwszy przedmiot waży 1 -> zmiesci sie
            problem.items[1].Weight = 5;
            problem.items[2].Weight = 10;
            Result result = problem.Solve(3); //w plecaku sa 3 miejsca
            Assert.IsTrue(result.Items.Count > 0); //zawsze powinnien zmieścić się jakiś przedmiot
        }

        [TestMethod]
        public void ItemsTooHeavy() // test, czy żaden przedmiot nie zmieści się, jeśli nie ma wystarczająco miejsca
        {
            Problem problem = new Problem(1, 3); //wygenerowano 3 przedmioty
            problem.items[0].Weight = 100; //pierwszy przedmiot waży 100
            problem.items[1].Weight = 100; //drugi przedmiot waży 100
            problem.items[2].Weight = 100; //trzeci przedmiot waży 100

            Result result = problem.Solve(10); //w plecaku jest 10 miejsc
            Assert.IsTrue(result.Items.Count == 0); //nie powinno się nic zmieścić
        }

        [TestMethod]
        public void ScenarioGreedy() //scenariusz z wikipedii
        {
            Problem problem = new Problem(1, 5);
            problem.items.Clear();
            problem.items.Add(new Item(0, 9, 10));
            problem.items.Add(new Item(1, 12, 7));
            problem.items.Add(new Item(2, 2, 1));
            problem.items.Add(new Item(3, 7, 3));
            problem.items.Add(new Item(4, 5, 2));

            Result result = problem.Solve(15);
            Assert.AreEqual("0 2", result.ToString());
        }

        [TestMethod]
        public void RNGRange() // test generowania liczb losowych z zakresu <1,10>
        {
            Problem problem = new Problem(1, 100);
            foreach (Item item in problem.items)
            {
                Assert.IsTrue(item.Weight >= 1 && item.Weight <= 10);
                Assert.IsTrue(item.Value >= 1 && item.Value <= 10);
            }
        }

        [TestMethod]

        public void ToStringParserEmpty() // test przeciazenia ToString dla pustego plecaka
        {
            Problem problem = new Problem(1, 1); //wygenerowano 1 przedmiot
            problem.items[0].Weight = 100; //pierwszy przedmiot waży 100
            Result result = problem.Solve(10); //w plecaku jest 10 miejsc
            Assert.AreEqual("", result.ToString()); // test przeciazenia ToString -- zwraca pusty string

        }

        [TestMethod]

        public void NoSpaceInBackpack()
        {
            Problem problem = new Problem(1, 5); //wygenerowano 5 przedmiotow
            Result result = problem.Solve(0); //w plecaku jest 0 miejsc
            Assert.AreEqual("", result.ToString()); // zwraca pusty plecak
        }

        



    }
}
