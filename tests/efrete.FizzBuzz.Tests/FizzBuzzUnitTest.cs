using NUnit.Framework;

namespace efrete.FizzBuzz.Tests;

public class FizzBuzzUnitTest
{
    private Dictionary<int, string[]> entradaSaida = new Dictionary<int, string[]>
        {
            { 3, new[] { "1", "2", "Fizz" } },
            { 5, new[] { "1","2","Fizz","4","Buzz" } },
            { 15, new[] {"1","2","Fizz","4","Buzz","Fizz","7","8","Fizz","Buzz","11","Fizz","13","14","FizzBuzz" } }
        };

    [TestCase(3)]
    [TestCase(5)]
    [TestCase(15)]
    public void MetodoTeste(int numeroTeste)
    {
        //Arrange

        //Act
        var resultado = FizzBuzz(numeroTeste).ToArray();

        //Assert
        var saidaEsperada = entradaSaida[numeroTeste];

        Assert.AreEqual(saidaEsperada.Length, resultado.Count());

        for (int i = 0; i < saidaEsperada.Length; i++)
        {
            Assert.AreEqual(saidaEsperada[i], resultado[i]);
        }
    }

    /*
     * Dado um número inteiro, retorne um array de string onde:
      resposta[i] == "FizzBuzz" se i for divisível por 3 e por 5
      resposta[i] == "Fizz" se i for divisível por 3
      resposta[i] == "Buzz" se i for divisível por 5
      resposta[i] == valor de i como string, caso nenhuma regra anterior tenha sido atendida
      Exemplo 1:
        Input: n = 3
        Output: ["1","2","Fizz"]

      Exemplo 2:
        Input: n = 5
        Output: ["1","2","Fizz","4","Buzz"]
      Exemplo 3:
        Input: n = 15
        Output: ["1","2","Fizz","4","Buzz","Fizz","7","8","Fizz","Buzz","11","Fizz","13","14","FizzBuzz"]
     */

    private IEnumerable<string> FizzBuzz(int valor)
    {
        var output = new List<string>();

        for (var i = 1; i <= valor; i++)
            output.Add(CheckFizzBuzzNumber(i));

        return output;
    }

    private string CheckFizzBuzzNumber(int num)
    {
        const int fizzNumber = 3;
        const int buzzNumber = 5;
        string output = string.Empty;

        if (num % fizzNumber == 0) output += "Fizz";
        if (num % buzzNumber == 0) output += "Buzz";

        return !string.IsNullOrEmpty(output)
               ? output
               : num.ToString();
    }
}