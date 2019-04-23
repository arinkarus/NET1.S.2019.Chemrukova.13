## Читать

- C# 6.0 in a Nutshell. Joseph Albahari, Ben Albahari. O'Reilly Media. 2015.
Chapter 7. Collections
- C# in Depth. Jon Skeet. Manning Publications Co. 2013. Chapter 6. Implementing iterators the easy way.
- C# 5.0 Unleashed. Bart De Smet. Sams Publishing. 2013. Chapter 15. Generic Types and Methods. Chapter 16. Collection Types.
- Pro .NET Performance: Optimize Your C# Applications. Sasha Goldshtein. Chapter 5. Collections and Generics
- CLR via C#. Jeffrey Richter. Microsoft Press. 2010. Chapter 12. Generics.

## Задачи

1. (deadline - 20.04.2019, 24.00) Переобразовать методы класса ArrayExtension [Day 10](https://github.com/AnzhelikaKravchuk/.NET-Training.-Spring-2019/tree/master/Day%2010%20-%2009.04.2019)
 в обобщенно-типизированные методы расширений типизированного интерфейса `IEnumerable<T>`
      
            public static IEnumerable<TSource> Filter<TSource>(this IEnumerable<TSource> source, IPredicate<TSource> predicate) { }
            
            public static IEnumerable<TResult> Transform<TSource,TResult>(this IEnumerable<TSource>, ITransformer<TSource, TResult> transformer) { }
            
            public static IEnumerable<TSource> SortBy<TSource>(this IEnumerable<TSource>, IComparer<TSource> comparer) { }`

Done - [**Day7**](https://github.com/arinkarus/NET1.S.2019.Chemrukova.07)  

2. (deadline - 21.04.2019, 24.00) Разработать обобщенный класс-коллекцию BinarySearchTree (бинарное дерево поиска). Предусмотреть возможности использования подключаемого интерфейса для реализации отношения порядка. Реализовать три способа обхода дерева: прямой (preorder), поперечный (inorder), обратный (postorder): для реализации обходов использовать блок-итератор (yield). Протестировать разработанный класс, используя следующие типы:
  - System.Int32 (использовать сравнение по умолчанию и подключаемый компаратор);
  - System.String (использовать сравнение по умолчанию и подключаемый компаратор);
  - пользовательский класс Book, для объектов которого реализовано отношения порядка (использовать сравнение по умолчанию и подключаемый компаратор);
  - пользовательскую структуру Point, для объектов которого не реализовано отношения порядка (использовать подключаемый компаратор).
  
Done

3. (deadline - 23.04.2019, 24.00) Заполните таблицу

Collection | Indexed lookup| Keyed lookup | Value lookup | Addition |  Removal |  Memory | 
-|-|-|-|-|-|-|
**Списки** | | | | | | |  
`T[]` | O(1) | - | - | - | - | Elements + additional info (like array's length) |
`List<T>` | O(1)| - | O(n)| O(1) amortized | O(n) | Array, array's capacity, count |
`LinkedList<T>` | - | - | - | O(1) | 	O(1), before/after given node | Head, count |
`Collection<T>` | O(1) | - | - | O(1) amortized | O(n) | |
`BindingList<T>` | O(1) | - | - | O(1) amortized | O(n) | |
`ObservableCollection<T>` | O(1) | - | - | O(1) amortized| O(n) | |
`KeyCollection<TKey,TItem>`  | O(1) | O(1), O(n) if collision (if dictionary is created) / O(n) |  | | | Holds Dictionary<TKey, TItem> instance.|
`ReadOnlyCollection<T>`  | | | | | | |
`ReadOnlyObservableCollection<T>`  | | | | | | |
**Словари** | | | | | | |  
`Dictionary<TKey, TValue>` | | | | | | | 
`SortedList<T>` | O(1) |  O(log n) | O(n) | O(n)* | O(n) | | 
`SortedDictionary<TKey,TValue>` | n/a | O(log n) | O(n) | O(log n) | O(log n) |  | 
`ReadOnlyDictionary<T>`  | | | | | | |
**Множества** | | | | | | | 
`HashSet<T>` | | | | | | | 
`SortedSet<T>` | | | | | | | 
**Очередь, стек** | | | | | | | 
`Queue<T>` | | | | | | | 
`Stack<T>` | | | | | | | 

* `*`Вставка O(1) для уже упорядоченных данных.
 
Collection | Underlying structure | Lookup strategy | Ordering | Contiguous storage | Data access | Exposes Key & Value collection | 
-|-|-|-|-|-|-|
**Списки** | | | | | | |  
`T[]` | System.Array | - | No | Yes | Index | No |
`List<T>` | Array | Linear search | No | Yes | Index | No |
`LinkedList<T>` | Nodes | Linear search | No | No | Property "Value" of node | No |
`Collection<T>` | `List<T>` | Linear search| No | Yes | Index | No |
`BindingList<T>` | `Collection<T>` | Linear search | No | Yes | Index | No |
`ObservableCollection<T>`  | `Collection<T>` | Linear search | No | Yes | Index | No |
`KeyCollection<TKey,TItem>`  | `Collection<T>`, Dictionary<TKey,TItem>` - instance is created if key count is greater than threshold  | Linear search / BinarySearch** | No |  | Key, Index | Yes. A requirement is that the key is somewhere inside the value. |
`ReadOnlyCollection<T>`  | | | | | | |
`ReadOnlyObservableCollection<T>`  | | | | | | |
**Словари** | | | | | | | 
`Dictionary<TKey, TValue>` | | | | | | |  
`SortedList<T>` | 2 arrays | Binary search | Sorted | Yes | Key, Index | Yes |
`SortedDictionary<TKey,TValue>` | BST | Binary search | Sorted | No | Key | Yes |
`ReadOnlyDictionary<T>`  | | | | | | |
**Множества** | | | | | | | 
`HashSet<T>` | | | | | | | 
`SortedSet<T>` | | | | | | | 
| | | | | | | 
**Очередь, стек** | | | | | | | 
`Queue<T>` | | | | | | | 
`Stack<T>` | | | | | | | 

** - The KeyedCollection<> can be configured to not create an internal Dictionary<>, depending on the number of items.
