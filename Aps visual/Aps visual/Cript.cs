/* Arquivo de criptografia e descriptografia */
using System;

namespace Cripto
{
    class arqc
    {
        /* #### Método fonte script #### */

        public static string script(string text, string cond, int n)
        {
            string encript;       // encript receberá o valor encriptado do método algc.
            string descript;      // decscript receberá o valor desencriptado do métod algd.
            string err = "erro de retorno";     // Mensagem de erro para return.

            char[] palav = text.ToCharArray();  // Palav recebe o texto convertido string da
            // execução de janelas .

            // Exceção adicionada para caso haja erros internos.
            try
            {
                // Condição para se caso o método recebe o valor cond cifrar.
                if (cond == "cifrar")
                {
                    // encript recebe o resultado do método algc.
                    encript = algc(palav, n);

                    return encript; // retorna o texto encriptado.
                }
                else
                {
                    // Condição para se caso o método recebe o valor cond decifrar.
                    if (cond == "decifrar")
                    {
                        // descript recebe o resultado do método algd.
                        descript = algd(n, text);

                        return descript; // retorna o texto desencriptado.
                    }
                }
            }
            // Caso haja erro retornara a string erro.
            catch
            {
                string erro = "erro de cifrar e decifrar";
                return erro;
            }
            return err; // Caso não haja nenhum retorno e a excessão seja driblada
        }               // retorne a string err.

        /* #### Método de conversão para ASCII #### */

        private static float[] ASC(char[] palava, int n)
        {
            int i, s = 0;                   // variáveis indices para futuros ciclos.
            int[] ASCII = new int[256];     // Array ASCII Receberá sua tabela.
            float[] conver = new float[n];  // Array conver Receberá o valor convertido.


            for (i = 0; i <= 255; ++i)  //       ## Ciclo de repetição ##
            {                           //  Repetição para que o vetor receba todos
                ASCII[i] = i;           //  os valores da tabela ASCII de 0 à 255.
            }

            for (i = 0; i < n; ++i)                             //        ## Ciclo para conversão ##
            {                                                   //  Converte o texto recebido em float para
                for (int h = 0; h < 255; ++h)                   //  ser devolvido e convertido para inteiro 
                {                                               //  em reconhecimento da tabela ASCII.
                    if (palava[i] == Convert.ToChar(ASCII[h]))
                    {
                        conver[s] = ASCII[h];
                        ++s;
                    }
                }
            }

            return conver;   // retorna o valor convertido
        }

        /* #### Método de criptografia #### */

        private static string algc(char[] palav, int n)
        {
            int i, w = 0;                // variáveis utilizadas para indices de ciclos .      

            float[] val, val2, keyx;    // val receberá o texto convertido em float,
            // val2 receberá a key2(chave secundária)com base 
            // na quantidade de caracteres convertida em float,
            // keyx receberá a key2 completamente, convertida em float.

            float[] result = new float[1000];         // Array result receberá o valor criptografado.
            char[] valg;                      // valg receberá o valor geral criptografado.
            string cifre;                     // string cifre que receberá o valor final para retornar.
            valg = new char[1000];
            val = new float[1000];      // Declarando os pesos dos Array.
            val2 = new float[1000];

            val = ASC(palav, n);        // val recebe o valor texto convertido.
            val2 = keys(n, out keyx);   // val2 recebe o valor key convertido, de forma inteira
            // e com base em n.


            for (i = 0; i < n; ++i)                             //    ## Ciclo for com algoritmo ##
            {                                                   // Ciclo no qual os valores textos serão
                result[w] = ((val[i] * val2[i]) - n);     // modificados e adicionados aos vetores 
                result[w += 1] = val2[i];
                ++w;                                            // convertidos em texto.
            }

            if (n < 15)
            {                                        //   ## Condição para texto menor que 15 ##
                for (i = 0; i < keyx.Length; ++i)
                {              // O vetor receberá um complemento para textos
                    result[w] = keyx[i] += n;                   // relativamente pequenos.
                    ++w;
                }
            }

            for (i = 0; i < w; ++i)                     //## Ciclo para conversão em caracteres ##
            {                                           // O Ciclo irá utilizar o auxiliar s para 
                int s;                                  // conversão de float para int e depois de
                s = Convert.ToInt32(result[i]);         // int para caracters armazenados no vetor
                valg[i] = Convert.ToChar(s);            // valg.
            }

            cifre = new string(valg); // Conversão de vetor char para uma string.

            return cifre;  // retornar o valor cifrado.
        }

        /* #### Método de descriptografia #### */

        private static string algd(int n, string palavra)
        {
            int x = n * 2; // x recebe o dobro de n para limpar o complemento de texto.
            int a = 0;

            float[] descript = new float[n]; // Declaração dos vetores que receberão o texto
            float[] cripts = new float[n];
            float[] ky = new float[n];
            char[] cifrelimp = new char[n];  // convertido em char e outro que recebera os valores
            // de descriptografia para conversão.

            if (n < 15)     // Se o texto limpo for menor que 15 limpe o resto.
            {
                palavra = palavra.Remove(x);
            }

            char[] palavcomp = palavra.ToCharArray(); // Palavcomp recebe e convert o texto composto em char[].

            for (int i = 0; i < n; ++i)
            {			//  ## Ciclo para separar os componentes compostos ##
                int e = Convert.ToInt32(palavcomp[a]);		// O ciclo utiliza auxiliares para passar o valor de
                cripts[i] = palavcomp[a];			// char[] to float[].

                int v = Convert.ToInt32(palavcomp[a += 1]);
                ky[i] = palavcomp[a];
                ++a;
            }

            for (int i = 0; i < n; ++i)                         //    ## Algoritmo de descriptografia ##
            {                                                   // O inverso do algoritmo de descriptografia
                descript[i] = ((cripts[i] + n) / ky[i]);           // para retornar o valor inicial do texto limpo.
            }

            for (int i = 0; i < n; ++i)
            {  // Ciclo para recebe conversão de float para char de forma direta.

                cifrelimp[i] = Convert.ToChar(Convert.ToInt32(descript[i]));
            }

            string palavralimpa = new string(cifrelimp); // Conversão de Array char para uma string palavralimpa.

            return palavralimpa; // retorna a string palavralimpa.

        }

        /* #### Método de chave secundário #### */
        // Serve para limpar o rastro de sequências no texto.

        private static float[] keys(int n, out float[] keyx)
        {

            int x = 0, s, i; // variáveis usadas para indices de ciclos. 

            char[] rept = {'k',',','s','i','d','j','w','k','g',  // Chave secundária para limpar rastro.
                           'p','i','e','b','c','k','i','e','3',
                           '4','2','2','3','j','b','d','k','#',
                           '4','$','8','3','j','a','k','.',','};

            char[] key = new char[1000]; // Declaração do Array que receberá
            // o rept com base em n(número de caracteres).

            for (i = 0, s = 0; i < n && s < n; ++i, ++s)    // ## Ciclo de armazenagem em sequência ##
            {                                               // O Array key receberá os valores de rept
                key[i] = rept[s];                           // com base na quantidade de caracteres 
                // utilizando auxiliar s como contador.
                if (s == 35 && i < n)
                {
                    s = 0;
                }

            }

            x = key.Length;    // X receberá a quantidade de pesos internos do vetor Key.          

            float[] key2 = new float[x]; // Declaração do Array key2 que irá receber
            // o valor convertido em float.

            key2 = ASC(key, x);  // Key2 recebe o valor de key convertido em float
            keyx = ASC(rept, rept.Length); // Keyx receber o valor de rept convertido em float

            return key2;   // retorna o valor de key2 ao método algc.              
        }
    }
}
