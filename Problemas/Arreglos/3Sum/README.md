# 3Sum

Dado un arreglo de enteros `nums`, devolver todos los tripletes `[nums[i], nums[j], nums[k]]` tales que `i != j`, `i != k`, y `j != k`, y `nums[i] + números[j] + números[k] == 0`.

**Tenga en cuenta que el conjunto de soluciones no debe contener tripletes duplicados.**

Para la solución de este problema tenemos tres estrategías una es  **tres punteros O(n²)**, la siguiente es usar **hash set O(n²)** y la última es usar la **búsqueda binaria O(n² log n)**, como hay una sección de búsqueda binaria en este repositorio, solo se mostrarán las dos primeras soluciones.

## Lenguaje C++

### Solución con hash set O(n²)

```cpp
class Solution {
public:
    std::vector<std::vector<int>> threeSum(std::vector<int> &nums)
    {
        std::vector<std::vector<int>> result;

        int n = nums.size();
        if (n < 3)
        {
            return result;
        }

        sort(nums.begin(), nums.end());

        for (int i = 0; i < n - 2; i++)
        {
            if (nums[i] > 0)
            {
                break;
            }
            if (i > 0 && nums[i - 1] == nums[i])
            {
                continue;
            }

            int j = i + 1;
            int k = n - 1;

            while (j < k)
            {
                int sum = nums[i] + nums[j] + nums[k];

                if (sum < 0)
                {
                    j++;
                }
                else if (sum > 0)
                {
                    k--;
                }
                else
                {
                    result.push_back({nums[i], nums[j], nums[k]});

                    while (j < k && nums[j] == nums[j + 1])
                    {
                        j++;
                    }
                    j++;

                    while (j < k && nums[k - 1] == nums[k])
                    {
                        k--;
                    }
                    k--;
                }
            }
        }
        return result;
    }
};
```

### Solución con hash set O(n²)

```cpp
class Solution {
public:
    std::vector<std::vector<int>> threeSum(std::vector<int>& nums) 
    {
        std::vector<std::vector<int>> result;
        int n = nums.size();

        if (n < 3) { return result; }

        std::sort(nums.begin(), nums.end());

        for (int i = 0; i < n - 2; ++i) 
        {
            if (i > 0 && nums[i] == nums[i - 1]) 
            {
                continue;
            }

            int target = -nums[i];
            std::unordered_set<int> hashSet;

            for (int j = i + 1; j < n; ++j) 
            {
                int complement = target - nums[j];

                if (hashSet.find(complement) != hashSet.end()) {
                    result.push_back({nums[i], nums[j], complement});

                    while (j + 1 < n && nums[j] == nums[j + 1]) {
                        ++j;
                    }
                }

                hashSet.insert(nums[j]);
            }
        }

        return result;
    }
};
```
