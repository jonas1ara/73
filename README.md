# 73 - El mejor número 🤓

Según Sheldon Cooper **el mejor número es el 73**, porque 73 es el 21er número primo. Su espejo, 37, es el 12mo número primo. 21 es el producto de multiplicar 7 por 3 y en binario, 73 es un palíndromo: 1001001

![73](/Sources/Sheldon.gif)

_Sheldon Cooper (personaje de la famosa serie "La teoría del Big-Bang")_

## ¿Qué es esto? 🚀

Este es un repositorio que te llevará de la mano en los 73 problemas de LeetCode más utiles, bueno en realidad son [76](https://leetcode.com/list/xi4ci4ig/) 😬, los algoritmos están escritos en C y C++, escribí cada programa colocando la función que lo resuelve, el resto del programa para poder ser probado on-promise, un README con notas del problema y de la solución. Al final si todo sale bien, haré un video en YouTube explicando cada problema 🤓

**Nota: Lo valioso de este repositorio es cuando te das cuenta que no existe material de calidad en español, entonces, si te ayuda, por favor dale una estrella, forkealo, guardalo o compártelo, me ayudarías bastante** 

## Estructura del repositorio 📦

El repositorio esta dividido en 4 carpetas:

```
|- Repositorio
    |- .vscode
        |- tasks.json
    |- Libraries
        |- ArrayPrinter.h
    |- Moderno
        |- Bind
        |- Contenedores
            |- Vector
                |- Vector.cpp
                |- README.md
        |- Delegados
        |- Enum 
        |- Lambda
        |- Novatadas
        |- Plantillas
        |- Range-for-y-auto
        |- Smart-pointers
    |- Problemas
        |- Arreglos
            |- Two-Sum
                |- Two-Sum.c
                |- Two-Sum.cpp
                |- README.md
        |- Matrices
        |- Strings
        |- Intervalos
        |- Búsqueda binaria
        |- Programación dinámica
        |- Listas enlazadas
        |- Árboles
        |- Heaps
        |- Grafos
    |- Sources
        |- Sheldon.gif
```

- **.vscode:** Contiene el archivo `tasks.json` que configura la tarea de compilación en Visual Studio Code

- **Libraries:** Contiene las librerias que se usan en el repositorio, por ejemplo la libreria `ArrayPrinter.h` que contiene funciones genericas para imprimir distintos arreglos

- **Moderno:** C++ moderno es extremandamente extenso cada cierto tiempo es bueno ayudar a la memoria a repasar ciertos temas para su comprensión, dentro de esta carpeta encontrarás explicaciones de funciones esenciales de C++ que se ocupan en este repositorio, cada subcarpeta es un tema con el código fuente y el README que explica dicho tema, por ejemplo la carpeta `Vector` contiene el código fuente en C++ `Vector.cpp` y el  archivo `README.md`. **Recomiendo encarecidamente leer por completo la sección `Novatadas` que contiene una serie de buenas practicas y consejos para programar en C++**

- **Problemas:** Contiene las carpetas de cada tema, dentro tiene una carpeta por problema y dentro de cada carpeta esta el código fuente y el README que explica dicho problema, por ejemplo la carpeta `Arreglos` contiene la carpeta `Two-Sum` que contiene el código fuente en C `Two-Sum.c` **(Solo en el primer problema de cada tema hay una implementación en lenguaje C para profundizar un poco más)**, el código fuente en C++ `Two-Sum.cpp` y el  archivo `README.md`

- **Sources:** Contiene las imágenes y gifs que se usan en el repositorio, por ejemplo el gif de Sheldon Cooper 😁

## Configuración 🔧

Puedes usar este repositorio desde Windows o Mac pero esta pensando para usarse en Linux, **especificamente una distribución basada en Debian**, por el script `Setup.sh` y el archivo `tasks.json`que configura la tarea de compilación en Visual Studio Code, no importa si es una distro completa o una WSL, lo importante es que tengas instalado:

- gcc
- g++
- libstdc++-dev

Para instalarlos en Debian o Ubuntu puedes usar:

```bash
sudo apt build-essential -y
```

## Indice 📖

### Arreglos 

| # | Titulo | Solución | Dificultad |
|---| ----- | -------- | ---------- |
|**0001**|[Two Sum](https://leetcode.com/problems/two-sum/) | [C - C++](https://github.com/Jonas-Lara/73/tree/main/Problemas/Arreglos/Two-Sum)|Baja|
|**0011**|[Container With Most Water](https://leetcode.com/problems/container-with-most-water/) | [C++](https://github.com/Jonas-Lara/73/tree/main/Problemas/Arreglos/Container-with-Most-Water)|Media|
|**0015**|[3Sum](https://leetcode.com/problems/3sum/) | [C++](https://github.com/Jonas-Lara/73/tree/main/Problemas/Arreglos/3Sum)|Media|
|0033|[Search in Rotated Sorted Array](https://leetcode.com/problems/search-in-rotated-sorted-array/) | [C++](https://github.com/Jonas-Lara/73/tree/main/Problemas/Arreglos/Search-in-Rotated-Sorted-Array)|Media|
|0053|[Maximum Subarray](https://leetcode.com/problems/maximum-subarray/) | [C++](https://github.com/Jonas-Lara/73/tree/main/Problemas/Arreglos/Maximum-Subarray)|Media|
|0121|[Best Time to Buy and Sell Stock](https://leetcode.com/problems/best-time-to-buy-and-sell-stock/) | [C++](https://github.com/Jonas-Lara/73/tree/main/Problemas/Arreglos/Best-Time-to-Buy-and-Sell-Stock)|Media|
|0152|[Maximum Product Subarray](https://leetcode.com/problems/maximum-product-subarray/) | [C++](https://github.com/Jonas-Lara/73/tree/main/Problemas/Arreglos/Maximum-Product-Subarray)|Media|
|0153|[Find Minimum in Rotated Sorted Array](https://leetcode.com/problems/find-minimum-in-rotated-sorted-array/) | [C++](https://github.com/Jonas-Lara/73/tree/main/Problemas/Arreglos/Find-Minimum-in-Rotated-Sorted-Array)|Media|
|0217|[Contains Duplicate](https://leetcode.com/problems/contains-duplicate/) | [C++](https://github.com/Jonas-Lara/73/tree/main/Problemas/Arreglos/Contains-Duplicate)|Baja|
|0238|[Product of Array Except Self](https://leetcode.com/problems/product-of-array-except-self/) | [C++](https://github.com/Jonas-Lara/73/tree/main/Problemas/Arreglos/Product-of-Array-Except-Self)|Baja|


### Matrices

| # | Titulo | Solución | Dificultad |
|---| ----- | -------- | ---------- |
|0048|[Rotate Image](https://leetcode.com/problems/rotate-image/) | [C - C++](https://github.com/Jonas-Lara/73/tree/main/Problemas/Matrices/Rotate-Image)|Media|
|0054|[Spiral Matrix](https://leetcode.com/problems/spiral-matrix/) | [C++](https://github.com/Jonas-Lara/73/tree/main/Problemas/Matrices/Spiral-Matrix)|Media|
|0073|[Set Matrix Zeroes](https://leetcode.com/problems/set-matrix-zeroes/) | [C++](https://github.com/Jonas-Lara/73/tree/main/Problemas/Matrices/Set-Matrix-Zeroes)|Media|
|0079|[Word Search](https://leetcode.com/problems/word-search/) | [C++](https://github.com/Jonas-Lara/73/tree/main/Problemas/Matrices/Word-Search)|Media|

### Strings

| # | Titulo | Solución | Dificultad |
|---| ----- | -------- | ---------- |
|0003|[Longest Substring Without Repeating Characters](https://leetcode.com/problems/longest-substring-without-repeating-characters/) | [C - C++](https://github.com/Jonas-Lara/73/tree/main/Problemas/Strings/Longest-Substring-Without-Repeating-Characters)|Media|
|0005|[Longest Palindromic Substring](https://leetcode.com/problems/longest-palindromic-substring/) | [C++](https://github.com/Jonas-Lara/73/tree/main/Problemas/Strings/Longest-Palindromic-Substring)|Media|
|0020|[Valid Parentheses](https://leetcode.com/problems/valid-parentheses/) | [C++](https://github.com/Jonas-Lara/73/tree/main/Problemas/Strings/Valid-Parentheses)|Baja|
|0049|[Group Anagrams](https://leetcode.com/problems/group-anagrams/) | [C++](https://github.com/Jonas-Lara/73/tree/main/Problemas/Strings/Group-Anagrams)|Media|
|0076|[Minimum Window Substring](https://leetcode.com/problems/minimum-window-substring/) | [C++](https://github.com/Jonas-Lara/73/tree/main/Problemas/Strings/Minimum-Window-Substring)|Alta|
|0125|[Valid Palindrome](https://leetcode.com/problems/valid-palindrome/) | [C++](https://github.com/Jonas-Lara/73/tree/main/Problemas/Strings/Valid-Palindrome)|Baja|
|0242|[Valid Anagram](https://leetcode.com/problems/valid-anagram/) | [C++](https://github.com/Jonas-Lara/73/tree/main/Problemas/Strings/Valid-Anagram)|Baja|
|0271|[Encode and Decode Strings](https://www.lintcode.com/problem/659/) | [C++](https://github.com/Jonas-Lara/73/tree/main/Problemas/Strings/Encode-and-Decode-Strings)|Media|   
|0424|[Longest Repeating Character Replacement](https://leetcode.com/problems/longest-repeating-character-replacement/) | [C++](https://github.com/Jonas-Lara/73/tree/main/Problemas/Strings/Longest-Repeating-Character-Replacement)|Media|
|0647|[Palindromic Substrings](https://leetcode.com/problems/palindromic-substrings/) | [C++](https://github.com/Jonas-Lara/73/tree/main/Problemas/Strings/Palindromic-Substrings)|Media|

### Intervalos

| # | Titulo | Solución | Dificultad |
|---| ----- | -------- | ---------- |
|0056|[Merge Intervals](https://leetcode.com/problems/merge-intervals/) | [C - C++](https://github.com/Jonas-Lara/73/tree/main/Problemas/Intervalos/Merge-Intervals)|Media|
|0057|[Insert Interval](https://leetcode.com/problems/insert-interval/) | [C++](https://github.com/Jonas-Lara/73/tree/main/Problemas/Intervalos/Insert-Interval)|Media|
|0252|[Meeting Rooms](https://www.lintcode.com/problem/920/) | [C++](https://github.com/Jonas-Lara/73/tree/main/Problemas/Intervalos/Meeting-Rooms)|Baja|
|0253|[Meeting Rooms II](https://www.lintcode.com/problem/919/) | [C++](https://github.com/Jonas-Lara/73/tree/main/Problemas/Intervalos/Meeting-Rooms-II)|Media|
|0435|[Non-overlapping Intervals](https://leetcode.com/problems/non-overlapping-intervals/) | [C++](https://github.com/Jonas-Lara/73/tree/main/Problemas/Intervalos/Non-overlapping-Intervals)|Media|

### Búsqueda binaria

| # | Titulo | Solución | Dificultad |
|---| ----- | -------- | ---------- |
|0190|[Reverse Bits](https://leetcode.com/problems/reverse-bits/) | [C - C++](https://github.com/Jonas-Lara/73/tree/main/Problemas/B%C3%BAsqueda-binaria/Reverse-Bits)|Baja|
|0191|[Number of 1 Bits](https://leetcode.com/problems/number-of-1-bits/) | [C++](https://github.com/Jonas-Lara/73/tree/main/Problemas/B%C3%BAsqueda-binaria/Number-of-1-Bits)|Baja|
|0268|[Missing Number](https://leetcode.com/problems/missing-number/) | [C++](https://github.com/Jonas-Lara/73/tree/main/Problemas/B%C3%BAsqueda-binaria/Missing-Number)|Baja|
|0338|[Counting Bits](https://leetcode.com/problems/counting-bits/) | [C++](https://github.com/Jonas-Lara/73/tree/main/Problemas/B%C3%BAsqueda-binaria/Counting-Bits)|Baja|
|0371|[Sum of Two Integers](https://leetcode.com/problems/sum-of-two-integers/) | [C++](https://github.com/Jonas-Lara/73/tree/main/Problemas/B%C3%BAsqueda-binaria/Sum-of-Two-Integers)|Medium|

### Programación dinámica

| # | Titulo | Solución | Dificultad |
|---| ----- | -------- | ---------- |
|0055|[Jump Game](https://leetcode.com/problems/jump-game/) | [C - C++](https://github.com/Jonas-Lara/73/tree/main/Problemas/Programaci%C3%B3n-din%C3%A1mica/Jump-Game)|Media|
|0062|[Unique Paths](https://leetcode.com/problems/unique-paths/) | [C++](https://github.com/Jonas-Lara/73/tree/main/Problemas/Programaci%C3%B3n-din%C3%A1mica/Unique-Paths)|Media|
|0070|[Climbing Stairs](https://leetcode.com/problems/climbing-stairs/) | [C++](https://github.com/Jonas-Lara/73/tree/main/Problemas/Programaci%C3%B3n-din%C3%A1mica/Climbing-Stairs)|Baja|
|0091|[Decode Ways](https://leetcode.com/problems/decode-ways/) | [C++](https://github.com/Jonas-Lara/73/tree/main/Problemas/Programaci%C3%B3n-din%C3%A1mica/Decode-Ways)|Media|
|0139|[Word Break](https://leetcode.com/problems/word-break/) | [C++](https://github.com/Jonas-Lara/73/tree/main/Problemas/Programaci%C3%B3n-din%C3%A1mica/Word-Break)|Media|
|0198|[House Robber](https://leetcode.com/problems/house-robber/) | [C++](https://github.com/Jonas-Lara/73/tree/main/Problemas/Programaci%C3%B3n-din%C3%A1mica/House-Robber)|Media|
|0213|[House Robber II](https://leetcode.com/problems/house-robber-ii/) | [C++](https://github.com/Jonas-Lara/73/tree/main/Problemas/Programaci%C3%B3n-din%C3%A1mica/House-Robber-II)|Media|
|0300|[Longest Increasing Subsequence](https://leetcode.com/problems/longest-increasing-subsequence/) | [C++](https://github.com/Jonas-Lara/73/tree/main/Problemas/Programaci%C3%B3n-din%C3%A1mica/Longest-Common-Subsequence)|Media|
|0322|[Coin Change](https://leetcode.com/problems/coin-change/) | [C++](https://github.com/Jonas-Lara/73/tree/main/Problemas/Programaci%C3%B3n-din%C3%A1mica/Coin-Change)|Media|
|0377|[Combination Sum IV](https://leetcode.com/problems/combination-sum-iv/) | [C++](https://github.com/Jonas-Lara/73/tree/main/Problemas/Programaci%C3%B3n-din%C3%A1mica/Combination-Sum-IV)|Media|
|1143|[Longest Common Subsequence](https://leetcode.com/problems/longest-common-subsequence/) | [C++](https://github.com/Jonas-Lara/73/tree/main/Problemas/Programaci%C3%B3n-din%C3%A1mica/Longest-Increasing-Subsequence)|Media|

### Listas enlazadas

| # | Titulo | Solución | Dificultad |
|---| ----- | -------- | ---------- |
|0019|[Remove Nth Node From End of List](https://leetcode.com/problems/remove-nth-node-from-end-of-list/) | [C - C++](https://github.com/Jonas-Lara/73/tree/main/Problemas/Listas-enlazadas/Remove-Nth-Node-From-End-of-List)|Media|
|0021|[Merge Two Sorted Lists](https://leetcode.com/problems/merge-two-sorted-lists/) | [C++](https://github.com/Jonas-Lara/73/tree/main/Problemas/Listas-enlazadas/Merge-Two-Sorted-Lists)|Baja|
|0023|[Merge k Sorted Lists](https://leetcode.com/problems/merge-k-sorted-lists/) | [C++](https://github.com/Jonas-Lara/73/tree/main/Problemas/Listas-enlazadas/Merge-k-Sorted-Lists)|Alta|
|0141|[Linked List Cycle](https://leetcode.com/problems/linked-list-cycle/) | [C++](https://github.com/Jonas-Lara/73/tree/main/Problemas/Listas-enlazadas/Linked-List-Cycle)|Baja|
|0143|[Reorder List](https://leetcode.com/problems/reorder-list/) | [C++](https://github.com/Jonas-Lara/73/tree/main/Problemas/Listas-enlazadas/Reorder-List)|Media|
|0206|[Reverse Linked List](https://leetcode.com/problems/reverse-linked-list/) | [C++](https://github.com/Jonas-Lara/73/tree/main/Problemas/Listas-enlazadas/Reverse-Linked-List)|Baja|

### Árboles

| # | Titulo | Solución | Dificultad |
|---| ----- | -------- | ---------- |
|0098|[Validate Binary Search Tree](https://leetcode.com/problems/validate-binary-search-tree/) | [C - C++](https://github.com/Jonas-Lara/73/tree/main/Problemas/%C3%81rboles/Validate-Binary-Search-Tree)|Media|
|0100|[Same Tree](https://leetcode.com/problems/same-tree/) | [C++](https://github.com/Jonas-Lara/73/tree/main/Problemas/%C3%81rboles/Same-Tree)|Baja|
|0102|[Binary Tree Level Order Traversal](https://leetcode.com/problems/binary-tree-level-order-traversal/) | [C++](https://github.com/Jonas-Lara/73/tree/main/Problemas/%C3%81rboles/Binary-Tree-Level-Order-Traversal)|Media|
|0104|[Maximum Depth of Binary Tree](https://leetcode.com/problems/maximum-depth-of-binary-tree/) | [C++](https://github.com/Jonas-Lara/73/tree/main/Problemas/%C3%81rboles/Maximum-Depth-of-Binary-Tree)|Baja|
|0105|[Construct Binary Tree from Preorder and Inorder Traversal](https://leetcode.com/problems/construct-binary-tree-from-preorder-and-inorder-traversal/) | [C++](https://github.com/Jonas-Lara/73/tree/main/Problemas/%C3%81rboles/Construct-Binary-Tree-from-Preorder-and-Inorder-Traversal)|Media|
|0124|[Binary Tree Maximum Path Sum](https://leetcode.com/problems/binary-tree-maximum-path-sum/) | [C++](https://github.com/Jonas-Lara/73/tree/main/Problemas/%C3%81rboles/Binary-Tree-Maximum-Path-Sum)|Alta|
|0208|[Implement Trie (Prefix Tree)](https://leetcode.com/problems/implement-trie-prefix-tree/) | [C++](https://github.com/Jonas-Lara/73/tree/main/Problemas/%C3%81rboles/Implement-Trie-Prefix-Tree)|Media|
|0211|[Design Add and Search Words Data Structure](https://leetcode.com/problems/design-add-and-search-words-data-structure/) | [C++](https://github.com/Jonas-Lara/73/tree/main/Problemas/%C3%81rboles/Design-Add-and-Search-Words-Data-Structure)|Media|
|0212|[Word Search II](https://leetcode.com/problems/word-search-ii/) | [C++](https://github.com/Jonas-Lara/73/tree/main/Problemas/%C3%81rboles/Word-Search-II)|Alta|
|0226|[Invert Binary Tree](https://leetcode.com/problems/invert-binary-tree/) | [C++](https://github.com/Jonas-Lara/73/tree/main/Problemas/%C3%81rboles/Invert-Binary-Tree)|Alta|
|0230|[Kth Smallest Element in a BST](https://leetcode.com/problems/kth-smallest-element-in-a-bst/) | [C++](https://github.com/Jonas-Lara/73/tree/main/Problemas/%C3%81rboles/Kth-Smallest-Element-in-a-BST)|Media|
|0235|[Lowest Common Ancestor of a Binary Search Tree](https://leetcode.com/problems/lowest-common-ancestor-of-a-binary-search-tree/) | [C++](https://github.com/Jonas-Lara/73/tree/main/Problemas/%C3%81rboles/Lowest-Common-Ancestor-of-a-Binary-Search-Tree)|Media|
|0207|[Serialize and Deserialize Binary Tree](https://leetcode.com/problems/serialize-and-deserialize-binary-tree/) | [C++](https://github.com/Jonas-Lara/73/tree/main/Problemas/%C3%81rboles/Serialize-and-Deserialize-Binary-Tree)|Alta|
|0572|[Subtree of Another Tree](https://leetcode.com/problems/subtree-of-another-tree/) | [C++](https://github.com/Jonas-Lara/73/tree/main/Problemas/%C3%81rboles/Subtree-of-Another-Tree)|Baja|

### Heaps

| # | Titulo | Solución | Dificultad |
|---| ----- | -------- | ---------- |
|0023|[Merge k Sorted Lists](https://leetcode.com/problems/merge-k-sorted-lists/) | [C - C++](https://github.com/Jonas-Lara/73/tree/main/Problemas/Heaps/Merge-k-Sorted-Lists)|Alta|
|0295|[Find Median from Data Stream](https://leetcode.com/problems/find-median-from-data-stream/) | [C++](https://github.com/Jonas-Lara/73/tree/main/Problemas/Heaps/Find-Median-from-Data-Stream)|Alta|
|0347|[Top K Frequent Elements](https://leetcode.com/problems/top-k-frequent-elements/) | [C++](https://github.com/Jonas-Lara/73/tree/main/Problemas/Heaps/Top-K-Frequent-Elements)|Media|

### Grafos

| # | Titulo | Solución | Dificultad |
|---| ----- | -------- | ---------- |
|0128|[Longest Consecutive Sequence](https://leetcode.com/problems/longest-consecutive-sequence/) | [C - C++](https://github.com/Jonas-Lara/73/tree/main/Problemas/Grafos/Longest-Consecutive-Sequence)|Media|
|0133|[Clone Graph](https://leetcode.com/problems/clone-graph/) | [C++](https://github.com/Jonas-Lara/73/tree/main/Problemas/Grafos/Clone-Graph)|Media|
|0200|[Number of Islands](https://leetcode.com/problems/number-of-islands/) | [C++](https://github.com/Jonas-Lara/73/tree/main/Problemas/Grafos/Number-of-Islands)|Media|
|0207|[Course Schedule](https://leetcode.com/problems/course-schedule/) | [C++](https://github.com/Jonas-Lara/73/tree/main/Problemas/Grafos/Course-Schedule)|Media|
|0261|[Graph Valid Tree](https://www.lintcode.com/problem/178/) | [C++](https://github.com/Jonas-Lara/73/tree/main/Problemas/Grafos/Graph-Valid-Tree)|Media|
|0269|[Alien Dictionary](https://www.lintcode.com/problem/892/) | [C++](https://github.com/Jonas-Lara/73/tree/main/Problemas/Grafos/Alien-Dictionary)|Alta|
|0323|[Number of Connected Components in an Undirected Graph](https://leetcode.com/problems/number-of-connected-components-in-an-undirected-graph/) | [C++](https://github.com/Jonas-Lara/73/tree/main/Problemas/Grafos/Number-of-Connected-Components-in-an-Undirected-Graph)|Media|
|0417|[Pacific Atlantic Water Flow](https://leetcode.com/problems/pacific-atlantic-water-flow/) | [C++](https://github.com/Jonas-Lara/73/tree/main/Problemas/Grafos/Pacific-Atlantic-Water-Flow)|Media|


## Construido con 🛠️

- [C](https://en.wikipedia.org/wiki/C_(programming_language)) (Opcional)
- [C++](https://isocpp.org/) (Obligatorio)
- [Ubuntu](https://ubuntu.com/) (Opcional)
- [VS Code](https://code.visualstudio.com/) (Opcional)

## Presentaciones 📊

- [Pontus Nyman: C++ in Space](https://www.youtube.com/watch?v=VxNVGVW9nyI)
- [Bjarne Stroustrup - The Essence of C++](https://www.youtube.com/watch?v=86xWVb4XIyE&list=PLAfTBTbGJEKI66gnV65ELkaVKiFmz1KdW&index=1)
- [CppCon 2015: Kate Gregory “Stop Teaching C"](https://www.youtube.com/watch?v=YnWhqhNdYyk&t=1215s)
- [Bjarne Stroustrup: C++ | Lex Fridman Podcast #48](https://www.youtube.com/watch?v=uTxRF5ag27A&t=2842s)
- [Bjarne Stroustrup: Why you should avoid Linked Lists](https://www.youtube.com/watch?v=YQs6IC-vgmo&list=PLAfTBTbGJEKI66gnV65ELkaVKiFmz1KdW&index=15)
- [Keynote: C++'s Superpower - Matt Godbolt - CPPP 2021](https://www.youtube.com/watch?v=0_UttFDnV3k&list=PLAfTBTbGJEKI66gnV65ELkaVKiFmz1KdW&index=7)
- [C++ - the Newest Old Language • Matt Godbolt • GOTO 2018](https://www.youtube.com/watch?v=HAFrggEDr5U&list=PLAfTBTbGJEKI66gnV65ELkaVKiFmz1KdW&index=10)
- [CppCon 2016: Jason Turner “Practical Performance Practices"](https://www.youtube.com/watch?v=uzF4u9KgUWI)
- [Can C++ be 10x Simpler & Safer? - Herb Sutter - CppCon 2022](https://www.youtube.com/watch?v=ELeZAKCN4tY&list=PLAfTBTbGJEKI66gnV65ELkaVKiFmz1KdW&index=14)
- [C++ in Constrained Environments - Bjarne Stroustrup - CppCon 2022](https://www.youtube.com/watch?v=2BuJjaGuInI)
- [CppCon 2017: Bjarne Stroustrup “Learning and Teaching Modern C++”](https://www.youtube.com/watch?v=fX2W3nNjJIo&list=PLAfTBTbGJEKI66gnV65ELkaVKiFmz1KdW&index=17)
- [Keynote: "Am I A Good Programmer?" - Kate Gregory - CppNorth 2022](https://www.youtube.com/watch?v=pdHvC8fDC5E&t=1420s)
- [Modern C++ Safety and Security At 20 - Matthew Butler - CppCon 2020](https://www.youtube.com/watch?v=uccarZGpDhk&t=2422s)
- [CppCon 2017: Peter Goldsborough “A Tour of Deep Learning With C++”](https://www.youtube.com/watch?v=Lo1rXJdAJ7w)
- [CppCon 2017: Louis Brandy “Curiously Recurring C++ Bugs at Facebook”](https://www.youtube.com/watch?v=lkgszkPnV8g)
- [CppCon 2018: Peter Goldsborough “Machine Learning in C++ with PyTorch”](https://www.youtube.com/watch?v=auRPXMMHJzc)
- [How C++23 Changes the Way We Write Code - Timur Doumler - CppCon 2022](https://www.youtube.com/watch?v=eD-ceG-oByA)
- [CppCon 2014: Herb Sutter "Back to the Basics! Essentials of Modern C++ Style"](https://www.youtube.com/watch?v=xnqTKD8uD64&t=4814s)
- [CppCon 2016: Bjarne Stroustrup "The Evolution of C++ Past, Present and Future"](https://www.youtube.com/watch?v=_wzc7a3McOs&list=PLAfTBTbGJEKI66gnV65ELkaVKiFmz1KdW&index=4)
- [The Most Important Optimizations to Apply in Your C++ Programs - Jan Bielak - CppCon 2022](https://www.youtube.com/watch?v=qCjEN5XRzHc)
- [Trading at light speed: designing low latency systems in C++ - David Gross - Meeting C++ 2022](https://www.youtube.com/watch?v=8uAW5FQtcvE)
- [The Imperatives Must Go! [Functional Programming in Modern C++] - Victor Ciura - CppCon 2022](https://www.youtube.com/watch?v=M5HuOZ4sgJE)
- [Bjarne Stroustrup's Closing Keynote at Code Europe 2022 in Cracow – "How to evolve a language"](https://www.youtube.com/watch?v=UoLM-6n-Ktg&list=PLAfTBTbGJEKI66gnV65ELkaVKiFmz1KdW&index=3)
- [CppCon 2017: Carl Cook “When a Microsecond Is an Eternity: High Performance Trading Systems in C++”](https://www.youtube.com/watch?v=NH1Tta7purM&list=PLAfTBTbGJEKI66gnV65ELkaVKiFmz1KdW&index=16)
- [How Microsoft Uses C++ to Deliver Office - Huge Size, Small Components - Zachary Henkel CppCon 2022](https://www.youtube.com/watch?v=0QtX-nMlz0Q)
- [CppCon 2018: Gordon Brown “A Modern C++ Programming Model for GPUs using Khronos SYCL”](https://www.youtube.com/watch?v=miqZS6aS9K0)
- [CppCon 2017: Jan Babst “Driving Into the Future With Modern C++: A Look at Adaptive Autosar”](https://www.youtube.com/watch?v=YzyGgZ_RClw)
- [Writing Safety Critical Automotive Software for High Perf AI Hardware - Michael Wong - CppCon 2019](https://www.youtube.com/watch?v=F4GzsA00s5I)

## Referencias 📚

_cppreference.com. (s. f.). https://en.cppreference.com/w/_

_Eckel, B. (2004). Thinking in C++. [Thinking in C++](https://www.amazon.com/Thinking-C-Introduction-Standard-2nd/dp/0139798099/ref=sr_1_1?dchild=1&keywords=thinking+in+c%2B%2B&qid=1618383343&sr=8-1) (2nd ed.). Pearson._

_Cormen, T. H., Leiserson, C. E., Rivest, R. L. & Stein, C. (2009). [Introduction to Algorithms](https://www.amazon.com/Introduction-Algorithms-3rd-MIT-Press/dp/0262033844) (3rd ed.). MIT Press._

## Expresiones de Gratitud 🎁

_Escrito con ❤️ por [Jonas Lara](https://twitter.com/Jonas_1ara) estudiante de ingeniería en IA en el  [IPN](https://www.ipn.mx/), para quien sea que este interesado_
