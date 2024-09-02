
/*
- Caching is a mechanism that allows us to store data in a temporary storage area so that the next time it is needed, it can be served faster.
- Caching increases the memory consumption of a program due to data being stored temporarily.
- It reduces execution time at the expense of program memory (RAM).
- Only really helpful if we repeatedly want to retrieve data identified by the same key, otherwise we are wastefully caching data.
- It is most often used to retrieve data from external resources, but can be used to cache, for example, data calculated from local memory.
- You must be aware that the underlying data may change, meaning cached data may become stale (outdatad). A mechanism that removes data from cache
  after some time can mitigate this issue.
*/
using System;

namespace _05_GenericTypesAndAdvancesUseOfMethods;

public class CachingBas
{

}
