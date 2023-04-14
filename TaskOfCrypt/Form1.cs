using System.Text;
using System.Text.RegularExpressions;

namespace TaskOfCrypt
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        
        char[] cryptAphabet; //алфавит из шифровательных букв для соответсвия с базовым
        string key; //преобразованный ключ
        char[] baseAphabet = new char[] {'А', 'Б', 'В','Г','Д','Е','Ё',
            'Ж','З','И','Й','К','Л',
            'М','Н', 'О','П','Р','С','Т','У','Ф','Х','Ц','Ч',
            'Ш', 'Щ', 'Ъ', 'Ы', 'Ь', 'Э', 'Ю','Я' }; //базовый алфавит
        Dictionary<int, char> cryptKey; // словарь соответсвия числу последовательности и буквенному символу
        enum Mode {  //логический флаг: шифрование или дешифрование
        crypt=0,
        decrypt=1
        }
        enum Method //логический флаг: тип метода
        {
            MonoAlphabet = 0,
            Permition = 1,
            Devide=2
        }
        private string generateCryptAlphabet(string keyUpgrade)
        {
            for (int i=0;i<baseAphabet.Length;i++)
            {
                if (!keyUpgrade.Contains(baseAphabet[i]))
                {
                    keyUpgrade += baseAphabet[i];
                }
            }
            return keyUpgrade;
        }

        private Dictionary<string, string> getDictionaryFromTwoArrays(char[] oneArray, char[] twoArray) {
            Dictionary<string, string> dict = new Dictionary<string, string>();
            for (int i = 0; i < oneArray.Length; i++)
            {
                dict.Add(oneArray[i].ToString(), twoArray[i].ToString());
            }
            return dict;
        }

        private Dictionary<int, char> getCryptKey(char [] _cryptAphabet)
        {
            int [] orderCharNumbers = new int [_cryptAphabet.Length]; //массив для числовой последовательности
            Dictionary<int,char> cryptKey= new Dictionary<int,char> ();
            for(int i = 0; i < _cryptAphabet.Length; i++) //заполняем массив индексами букв исходного алфавита
            {
                orderCharNumbers[i]=Array.IndexOf(baseAphabet, _cryptAphabet[i])+1;
            }
            List <int> usedIndexes = new List<int>(); //список для уже использованных индексов, которые уже были заменены
            int minNumber = 10000;
            int minIndex = 0;
            int count = 1; 
            for (int i=0; i< orderCharNumbers.Length; i++) //проходимся по нашей числовой последовательности и заменяем индексы на число от 0 до n
            {
                //принцип такой: проходимся по массиву, ищем минимальный, пишем вместо мин числа счетчик(1), затем записываем идекс этого числа
                //в массив уже использованных индексов; находим следующее минимальное число, пишем вместо него счетчик(2) и.т.д
                minNumber = 10000;
                for (int k = 0; k < orderCharNumbers.Length; k++)
                {
                    if (orderCharNumbers[k] < minNumber && !usedIndexes.Contains(k))
                    {
                        minNumber = orderCharNumbers[k];
                        minIndex = k;
                    }
                }
                orderCharNumbers[minIndex] = count;
                usedIndexes.Add(minIndex);
                count += 1;
            }
            for(int i = 0; i < orderCharNumbers.Length; i++) // заполняем словарь соответсвия символа ключа и числу последовательности
            {
                cryptKey.Add(orderCharNumbers [i],key[i]);
            }
            return cryptKey;
        }
        /// <summary>
        /// Функция которая преобразует ключ: удаляет пробелы, симолы, в зависимости от метода, удаляет повторяющиеся символы
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonGenerateCryptAlhabet_Click(object sender, EventArgs e)
        {
            key = textBoxKey.Text; //преобразованный ключ
            key = key.ToUpper(); //верхний регистр
            key = key.Replace(" ", ""); //удаление ординарных пробелов
            key = key.Replace(",", ""); //удаление запятых
            key = key.Replace(".", ""); //удаление точек
            key = key.Replace(":", ""); //удаление двоеточий
            key = key.Replace("\r\n", ""); //удаление табуляции
            key = key.Trim(); //удаление пробелов в начале и конце
            if (radioButtonMonoAlphabet.Checked | radioButtonMethodOfDivide.Checked)
            {
                string keyWithoutDouble = "";
                for (int i = 0; i < key.Length; i++)
                {
                    if (!key.Substring(0, i).Contains(key[i]))
                    {
                        keyWithoutDouble += key[i];
                    }
                }
                key = keyWithoutDouble;
                string cryptStrAlphabet = generateCryptAlphabet(key); //дополненый ключ для моноалфавитного метода
                cryptAphabet = cryptStrAlphabet.ToCharArray();
            } else if (radioButtonPermutationMethod.Checked)
            {
                cryptAphabet = key.ToCharArray();
                cryptKey = getCryptKey(cryptAphabet); //словарь, в котом символ ключа соответсвует чилу последовательности от 0 до n
            }
            
        }

        private string toCryptOrDecrypt(int _mode, int _method)
        {
            string baseText; //преобразованный базовый текст
            baseText = textBoxBaseText.Text; 
            baseText = baseText.ToUpper();
            baseText = baseText.Trim();
            if (new int[] { 0,1,2}.Contains(_mode) && _mode==0)
            {
                baseText = baseText.Replace(" ", "");
                baseText = baseText.Replace(",", "");
                baseText = baseText.Replace(".", "");
                baseText = baseText.Replace(":", "");
                baseText = baseText.Replace(";", "");
                baseText = baseText.Replace("-", "");
            }
            var result = "";
            switch (_method)
            {
                case 0:
                    result=toCryptOrDecryptForMonoAlphabet(_mode, baseText);
                    break;
                case 1:
                    result= toCryptOrDecryptForPermutationMethod(_mode,baseText);
                    break;
                case 2:
                    result = toCryptOrDecryptForDevideMethod(_mode, baseText);
                    break;
            }
            return result;
        }


        private string toCryptOrDecryptForMonoAlphabet(int mode, string baseText){
            string cryptOrDecryptText = ""; //результирующий текст, после шифровки и дешифровки
            Dictionary<string, string> dictionaryCryptOrDecrypt = new Dictionary<string, string>(); //словарь соответсвий для расшифровки и дешифровки
                switch (mode)
                {
                    case 0:
                        dictionaryCryptOrDecrypt = getDictionaryFromTwoArrays(baseAphabet, cryptAphabet); //метод склеивающий два массива в один словарь
                        break;
                    case 1:
                        dictionaryCryptOrDecrypt = getDictionaryFromTwoArrays(cryptAphabet, baseAphabet); //метод склеивающий два массива в один словарь
                    break;
                }


                for (int i = 0; i < baseText.Length; i++) //заменяем каждый исходный символ на соответсвующий ему символ второго алфавита
                {
                    cryptOrDecryptText += dictionaryCryptOrDecrypt[baseText[i].ToString()];
                }
                return cryptOrDecryptText;
        }

        public string SplitStr(string str, int maxSymbols) // метод деления строки на равное количество символов
        {
            var sb = new StringBuilder();
            var counter = 0;
            foreach (var element in str)
            {
                if (counter == maxSymbols)
                {
                    sb.Append(" ");
                    counter = 0;
                }

                sb.Append(element);
                counter++;
            }
            return sb.ToString();
        }

        private string toCryptOrDecryptForPermutationMethod(int _mode,string _baseText)
        {
            Dictionary<int, string> dictionaryCryptOrDecrypt = new Dictionary<int, string>(); //словарь соответсвий для расшифровки и дешифровки
            int countSeparator = Convert.ToInt32(Math.Ceiling(_baseText.Length * 1.0 / cryptKey.Count)); //сколько строк будет в нашей таблице
            string cryptText; //зашифрованный текст
            if (_mode == 0) // зашифровка
            {
                for (int i = 0; i < _baseText.Length; i++) // записываем соответсие числовой последовательности и стобца в таблице по очереди
                {
                    int index = i % cryptKey.Count;
                    if (!dictionaryCryptOrDecrypt.Keys.Contains(cryptKey.Keys.ElementAt(index)))
                    {
                        dictionaryCryptOrDecrypt.Add(cryptKey.Keys.ElementAt(index), _baseText[index].ToString());
                    }
                    else
                    {
                        dictionaryCryptOrDecrypt[cryptKey.Keys.ElementAt(index)] = dictionaryCryptOrDecrypt.ElementAt(index).Value + _baseText[i].ToString();
                    }

                }
                for (int i = 0; i < dictionaryCryptOrDecrypt.Count; i++) //добавляем необходимые символы для равенства символов в каждом столбце
                {
                    while (dictionaryCryptOrDecrypt.ElementAt(i).Value.Length != countSeparator)
                    {
                        dictionaryCryptOrDecrypt[dictionaryCryptOrDecrypt.ElementAt(i).Key] += "_";
                    }
                }
                string res = "";
                for (int i = 0; i < cryptKey.Count; i++) // выписывываем в порядке возрастания соответсвующие столбцы числовой последовательности
                {
                    res += dictionaryCryptOrDecrypt[i + 1];
                }
                cryptText = SplitStr(res, 5); // делим текст по 5 симолов
                return cryptText;
            }
            else if (_mode == 1)  //расшифровка
            {
                cryptText = SplitStr(_baseText, countSeparator); //делим текст по длине ключа
                string[] blocks = cryptText.Split(" "); //собираем массив отдельных кусков текста
                string res = "";
                for (int i = 0; i < cryptKey.Count; i++) //создаем словарь соотвествий числовой последовательности и кусков текста
                {
                    dictionaryCryptOrDecrypt.Add(i + 1, blocks[i]);
                }
                for (int i = 0; i < countSeparator; i++) //теперь в порядке числовой последовательности ключа выписываем куски текста, образуя исходный
                {
                    for (int k = 0; k < cryptKey.Count; k++)
                    {
                        res += dictionaryCryptOrDecrypt[cryptKey.ElementAt(k).Key][i];
                    }
                }
                return res;
            }
            return String.Empty; 
        }

        private int [] getIndexFromTwoXMassiv(char [,] array,char value)
        {
            for (int i = 0; i < array.GetLength(0); i++)
            {
                for (int k = 0; k < array.GetLength(1); k++)
                {
                    if (value == array[i, k])
                    {
                        return new int[] { i, k };
                    }
                }
            }
            return null;
        }

        private string toCryptOrDecryptForDevideMethod(int mode, string baseText)
        {
            int lenghtColumnOrStr = getLenghtSquare(cryptAphabet.Length);
            char[,] squareCryptOrDecrypt = new char[lenghtColumnOrStr, lenghtColumnOrStr]; //квадрат Поллибия
            int count = 0;
            char [] addedSeparators = new char[] {'.',',','!',':',';','*','@','-','(',')'};
            string cryptText = "";
            for (int i = 0; i < lenghtColumnOrStr; i++)
            {
                for (int k = 0; k < lenghtColumnOrStr; k++)
                {
                    if (count < cryptAphabet.Length)
                    {
                       squareCryptOrDecrypt[i, k] = cryptAphabet[count];
                    }
                    else
                    {
                       squareCryptOrDecrypt[i, k] = addedSeparators[count%addedSeparators.Length];
                    }
                    count++;
                }
            }
            if (mode == 0)
            {
                int[] coordStr = new int[baseText.Length];
                int[] coordCol = new int[baseText.Length];
                for (int i = 0; i < baseText.Length; i++)
                {
                    coordStr[i] = getIndexFromTwoXMassiv(squareCryptOrDecrypt, Convert.ToChar(baseText[i]))[0];
                    coordCol[i] = getIndexFromTwoXMassiv(squareCryptOrDecrypt, Convert.ToChar(baseText[i]))[1];
                }
                for (int i = 0; i < coordStr.Length-1; i++)
                {
                    cryptText += squareCryptOrDecrypt[coordStr[i], coordStr[i+1]];
                    i++;
                }
                for (int i = 0; i < coordCol.Length-1; i++)
                {
                    cryptText += squareCryptOrDecrypt[coordCol[i], coordCol[i + 1]];
                    i++;
                }
                return cryptText;
            }
            else if(mode == 1)
            {
                string res = "";

                Queue<int> coords = new Queue<int>();
                for (int i = 0; i < baseText.Length; i++)
                {
                    coords.Enqueue(getIndexFromTwoXMassiv(squareCryptOrDecrypt, Convert.ToChar(baseText[i]))[0]);
                    coords.Enqueue(getIndexFromTwoXMassiv(squareCryptOrDecrypt, Convert.ToChar(baseText[i]))[1]);
                }
                int lenghtQueue = coords.Count;
                int[] coordStr = new int[lenghtQueue/2];
                int[] coordCol = new int[lenghtQueue/2];
                for (int i = 0; i < coordStr.Length; i++)
                {
                    coordStr[i] = coords.Dequeue();
                }
                for (int i = 0; i < coordCol.Length; i++)
                {
                    coordCol[i] = coords.Dequeue();
                }
                for (int i = 0; i < coordStr.Length; i++)
                {
                    res += squareCryptOrDecrypt[coordStr[i], coordCol[i]];
                }
                return res;
            }
            return String.Empty;
        }

        private int getLenghtSquare(int _lenghtAlphabet)
        {
            Dictionary<int, int> dictMultiplications = new Dictionary<int, int>();
            for(int i=0; i < 100; i++)
            {
                dictMultiplications.Add(i * i,i);
            }
            for (int i = 0; i < dictMultiplications.Count; i++)
            {
                if (dictMultiplications.ElementAt(i).Key>=_lenghtAlphabet)
                {
                    return dictMultiplications[dictMultiplications.ElementAt(i).Key];
                }
            } 
            return 0;
        }

        private void buttonCrypt_Click(object sender, EventArgs e)
        {
            buttonGenerateCryptAlhabet_Click(sender, e);
            if (radioButtonMonoAlphabet.Checked)
            {
                textBoxCryptText.Text = toCryptOrDecrypt(((int)Mode.crypt), ((int)Method.MonoAlphabet));
            } else if(
                radioButtonPermutationMethod.Checked)
            {
                textBoxCryptText.Text = toCryptOrDecrypt(((int)Mode.crypt), ((int)Method.Permition));
            } else if (radioButtonMethodOfDivide.Checked)
            {
                textBoxCryptText.Text = toCryptOrDecrypt(((int)Mode.crypt), ((int)Method.Devide));
            }

        }

        private void buttonDecrypt_Click(object sender, EventArgs e)
        {
            buttonGenerateCryptAlhabet_Click(sender, e);
            string decryptText ="";
            if (radioButtonMonoAlphabet.Checked)
            {
                decryptText = toCryptOrDecrypt(((int)Mode.decrypt), ((int)Method.MonoAlphabet));

            }
            else if (radioButtonPermutationMethod.Checked)
            {
                decryptText = toCryptOrDecrypt(((int)Mode.decrypt), ((int)Method.Permition));
            }
            else if (radioButtonMethodOfDivide.Checked)
            {
                decryptText = toCryptOrDecrypt(((int)Mode.decrypt), ((int)Method.Devide));
            }
            for (int i = 0; i < decryptText.Length; i++)
            {
                if (i % 6 == 0)
                {
                    decryptText = decryptText.Insert(i, " ");
                }
            }
            textBoxCryptText.Text = decryptText;

        }

    }
}