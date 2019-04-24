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
Collection | Indexed lookup | Keyed lookup | Value lookup | Addition | Removal | Memory | 
-|-|-|-|-|-|-|
**Списки** | | | | | | |  
`T[]` | O(1) | - | O(n) | O(n) | O(n) | |
`List<T>` | O(1)| - | O(n)| O(1)* | O(n – k) / O(n)** | |
`LinkedList<T>` | O(n) | - | O(n) | O(1), before/after given node, otherwise O(n) | O(1), before/after given node, otherwise O(n) | |
`Collection<T>` | O(1) | - | O(n) | O(1)* | O(n – k) / O(n)** | |
`BindingList<T>` | O(1) | - | O(n)| O(1)* | O(n – k) / O(n)** | |
`ObservableCollection<T>` | O(1) | - | O(n) | O(1)* | O(n – k) / O(n)** | |
`KeyCollection`  | - | - | O(1)(values is keys from `Dictionary<TKey, TValue>`) | - | - | |
`ReadOnlyCollection<T>`  | O(1) | - | O(n) | - | - | |
`ReadOnlyObservableCollection<T>`  | O(1) | - | O(n)  | - | - | |
**Словари** | | | | | | |  
`Dictionary<TKey, TValue>` | - | O(1) | O(n) | O(1) | O(1) | | 
`SortedList<TKey, TValue>` | O(1) | O(log n) | O(n) | O(n)**** | O(n) | | 
`SortedDictionary<TKey, TValue>` | - | O(log n) | O(n) | O(log n) | O(log n) | `SortedList<TKey, TValue>` uses less memory than `SortedDictionary<TKey,TValue>`. |
`ReadOnlyDictionary<TKey, TValue> `  | - | O(1) | O(n) | - | - | |
**Множества** | | | | | | | 
`HashSet<T>` | - | - | 	O(1)*** | O(1)*** | O(1)*** | | 
`SortedSet<T>` | - | - | O(log n) | O(log n) | O(log n) | | 
**Очередь, стек** | | | | | | | 
`Queue<T>` | O(1) | - | O(n) | O(1) | O(1) | | 
`Stack<T>` | O(1) | - | O(n) | O(1) | O(1) | |

**Словари** | | | | | | |  
`Dictionary<TKey, TValue>` | - | O(1) | O(n) | O(1) | O(1) | | 
`SortedList<TKey, TValue>` | O(1) | O(log n) | O(n) | O(n)**** | O(n) | | 
`SortedDictionary<TKey, TValue>` | - | O(log n) | O(n) | O(log n) | O(log n) | `SortedList<TKey, TValue>` uses less memory than `SortedDictionary<TKey,TValue>`. |
`ReadOnlyDictionary<TKey, TValue> `  | - | O(1) | O(n) | - | - | |
**Множества** | | | | | | | 
`HashSet<T>` | - | - | 	O(1)*** | O(1)*** | O(1)*** | | 
`SortedSet<T>` | - | - | O(log n) | O(log n) | O(log n) | | 
**Очередь, стек** | | | | | | | 
`Queue<T>` | O(1) | - | O(n) | O(1) | O(1) | | 
`Stack<T>` | O(1) | - | O(n) | O(1) | O(1) | |

* `*` If there is no need to expand array. Otherwise - O(n).
* `**` Removing complexity is O(n – k) where k is the index of the element you’re removing; trimming
the tail of a list is cheaper than removing the head. Removing by value instead of by index (Remove rather than
RemoveAt) - O(n).
* `***` O(n) if collision.
* `****` Insertion O(1) for already ordered data.
* `*****` Read-only => agregtion in constructor => Explicit interface implementations => `NotSupported_ReadOnlyCollection` at methods like Remove, Add, Clear ... .

Collection | Underlying structure | Lookup strategy | Ordering | Contiguous storage | Data access | Exposes Key & Value collection | 
-|-|-|-|-|-|-|
**Списки** | | | | | | |  
`T[]` | `System.Array` | Random access(O(1) Index) | No | Yes | Random access(O(1) Index) | No |
`List<T>` | Array | Random access(O(1) Index) | No | Yes | Random access(O(1) Index) | No |
`LinkedList<T>` | Nodes | Random access(O(1) Index) | No | No | Sequential access | No |
`Collection<T>` | `IList<T>` | Random access(O(1) Index) | No | Yes | Random access(O(1) Index) | No |
`BindingList<T>` | `IList<T>` | Random access(O(1) Index) | No | Yes | Random access(O(1) Index) | No |
`ObservableCollection<T>`  | `IList<T>` | Random access(O(1) Index) | No | Yes | Random access(O(1) Index) | No |
`KeyCollection`  | `Dictionary<TKey,TValue>` | Random access(O(1) value which is key of dictionary) Via Hashtable | No | Random access(O(1) value) | Yes. (values is keys from `Dictionary<TKey, TValue>`) |
`ReadOnlyCollection<T>`  | `IList<T>` | Random access(O(1) Index) | No | Yes | Random access(O(1) Index) | No |
`ReadOnlyObservableCollection<T>` | `IList<T>` | Random access(O(1) Index) | No | Yes | Random access(O(1) Index) | No |
**Словари** | | | | | | | 
`Dictionary<TKey, TValue>` | Hashtable | Random access(O(1) Key) Via Hashtable | No | No | Random access(O(1) Key) | Yes |  
`SortedList<TKey, TValue>` | `TKey[]` `TValue[]` `KeyList` `ValueList` | Random access(O(1) Index) or Binary search(log(n) Key) | Sorted | Yes | Random access(O(1) Index) or Binary search(log(n) Key) | Yes |
`SortedDictionary<TKey, TValue>` | Red-black tree | Binary search(log(n) Key) | Sorted | No | Binary search(log(n) Key) | Yes |
`ReadOnlyDictionary<TKey, TValue>`  | Hashtable | Random access(O(1) Key) Via Hashtable | No | No | Random access(O(1) Key) | Yes |
**Множества** | | | | | | | 
`HashSet<T>` | Hashtable | Random access(O(1) Value*) Via Hashtable | No | No | Random access(O(1) Value*) | No | 
`SortedSet<T>` | Red-black tree | Binary search(log(n) Value) | Sorted | No | Binary search(log(n) Value) | No | 
| | | | | | | 
**Очередь, стек** | | | | | | | 
`Queue<T>` | Array | Random access(O(1) Index) | No | Yes | Random access(O(1) Index), Pop() | No | 
`Stack<T>` | Array | Random access(O(1) Index) | No | Yes | Random access(O(1) Index), Pop() | No | 

* `*` `A HashSet<T>` class can be thought of as a `Dictionary<TKey, TValue>` collection without values.
