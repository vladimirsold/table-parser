# Table parser
На вход программе подается строка текста. На выход нужно вернуть массив полей, извлечённых из входа, либо пустой массив если полей нет.

Поля могут быть двух типов:

Простые поля
Не могут быть пустыми, не могут содержать пробелов и разделяются одним или несколькими пробелами.

Поля в кавычках
Могут содержать пробелы и быть пустыми. То есть строка  **a "bcd ef" 'x y'** содержит три поля **a**, **bcd ef** и **x y**, а не пять.

Кавычки разных типов могут быть вложенными. То есть строка **"a 'b' 'c' d" '"1" "2" "3"'** содержит два поля **a 'b' 'c' d** и **"1" "2" "3"**.

Поля, заключенные в кавычки, могут не отделяться от других полей пробелами. То есть строка **a"b c d e"f** содержит 3 поля **a, b c d e и f.**

Если в строке отсутствует последняя парная закрывающая кавычка, считать, что соответствующее поле заканчивается в конце строки. То есть строка **abc "def g h** содержит два поля.

Поле внутри кавычек может содержать символы кавычек, экранированные символом **'\'**. Символ **'\'** также может быть экранирован самим же собой. То есть строка **"a \"c\""** содержит одно поле, а строка **"\\" b** — два поля.

В простых полях символ **'\\'** не считается экранирующим символом, поэтому строка **\\\\** — это одно поле из двух слэшей, а **\"a b\"** — это два поля **\\** и **a b"**
