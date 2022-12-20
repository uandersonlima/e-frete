using NUnit.Framework;

namespace e_frete.NumerosRomanos.Tests;

public class NumerosRomanosTest
{
    // [TestCase("I", 1)]
    // [TestCase("V", 5)]
    // [TestCase("X", 10)]
    // [TestCase("L", 50)]
    // [TestCase("C", 100)]
    // [TestCase("D", 500)]
    // [TestCase("M", 1000)]
    [TestCase("IV", 4)]
    [TestCase("IX", 9)]
    [TestCase("XLIII", 43)]
    [TestCase("XLIV", 44)]
    [TestCase("III", 3)]
    [TestCase("LVIII", 58)]
    [TestCase("MCMXCIV", 1994)]
    [TestCase("MMMCMXCIX", 3999)]
    //Código só funciona até 3999, mais do que isso, ele desconhece os caracteres.
    public void Teste(string numeroRomano, int numeroInteiroEsperado)
    {
        //Arrange

        //Act
        var resultado = NumeroRomanoParaInteiro(numeroRomano);

        //Assert
        Assert.AreEqual(numeroInteiroEsperado, resultado);
    }

    /*
    Numeros romanos são repreentados por 7 diferentes simbolos: I, V, X, L, C, D e M.
    Simbolo     ValorValue
    I            1
    V            5
    X            10
    L            50
    C            100
    D            500
    M            1000
    Por exemplo, 2 é escrito II em romando, apenas dois 1's e somam-se. 12 é escrito XII, onde é simplesmente X(10) + II(2).
    O número 27 é escrito XXVII, onde XX(20) + V(5) + II(2)

    Numeros romanos são geralmente escritos do mais alto para o mais baixo da esquerda para a direita
    Porém o número 4 não é IIII, e sim IV. Desta maneira, o I(1) é menor que V(5), o que gera 5-1, que é 4
    O mesmo princípio se aplica ao número 9, que é escrito IX

    Há seis intancias onde a subtração é usada:
        I pode ser colocado antes de um V (5) e X (10) para gerar 4 e 9. 
        X pode ser colocado antes de um L (50) e C (100) para gerar 40 e 90. 
        C pode ser colocado antes de um D (500) e M (1000) para gerar 400 e 900.

    Visto isto, crie um método que converta um numero romano num inteiro
        Exemplo 1:
        Input: s = "III"
        Output: 3
        Explicação: III = 3.
        Exemplo 2:
        Input: s = "LVIII"
        Output: 58
        Explicação: L = 50, V= 5, III = 3.
        Exemplo 3:
        Input: s = "MCMXCIV"
        Output: 1994
        Explicação: M = 1000, CM = 900, XC = 90 and IV = 4. 
    Restrições:
        O tamanho do número romano enviado 1 <= s.length <= 15
        s contém apenas os caracteres a seguir ('I', 'V', 'X', 'L', 'C', 'D', 'M').
        É garantido que somente serão enviados números romanos no seguinte intervalo [1, 3999].
    */
    private int NumeroRomanoParaInteiro(string numeroRomano)
    {
        // inicia com o valor correspondente ao primeiro character, caso seja único, já retorna o valor
        var myNumber = ConvertCharacterToInteger(numeroRomano[0]);
        var previousNumber = 0;
        var currentNumber = 0;

        for (var i = 1; i < numeroRomano.Length; i++)
        {
            currentNumber = ConvertCharacterToInteger(numeroRomano[i]);
            previousNumber = ConvertCharacterToInteger(numeroRomano[i - 1]);

            //Se o numero atual for menor ou igual ao anterior ele soma
            if (previousNumber >= currentNumber)
            {
                myNumber += currentNumber;
            }
            //Caso contrário diminui meu número pelo dobro do anterior e somo ao atual
            else
            {
                myNumber = myNumber - previousNumber * 2 + currentNumber;
            }


        }

        return myNumber;
    }

    private int ConvertCharacterToInteger(char caracter)
    {
        switch (caracter)
        {
            case 'I': return 1;
            case 'V': return 5;
            case 'X': return 10;
            case 'L': return 50;
            case 'C': return 100;
            case 'D': return 500;
            case 'M': return 1000;
            default: return 0;
        }
    }
}