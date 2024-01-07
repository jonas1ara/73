#include <iostream>
#include <functional>
#include <queue>
#include <vector>
#include <cmath>

// Using two heaps - Time: O(log(n))

class MedianFinder {
    std::priority_queue<int> sm;
    std::priority_queue<int, std::vector<int>, std::greater<>> gt;

public:
    MedianFinder() {}

    void addNum(int num)
    {
        if (gt.size() && num > gt.top())
        {
            gt.push(num);
            if (gt.size() > sm.size())
            {
                sm.push(gt.top());
                gt.pop();
            }
        }
        else
        {
            sm.push(num);
            if (sm.size() > gt.size() + 1)
            {
                gt.push(sm.top());
                sm.pop();
            }
        }
    }
    double findMedian()
    {
        return sm.size() > gt.size() ? sm.top() : ((double)sm.top() + gt.top()) / 2;
    }
};

std::string join(const std::string& delimiter, const std::vector<std::string>& elements) {
    if (elements.empty()) {
        return "";
    }

    std::string result = elements[0];
    for (size_t i = 1; i < elements.size(); i++) {
        result += delimiter + elements[i];
    }

    return result;
}

int main() {
    MedianFinder medianFinder;

    std::cout << "Input" << std::endl;
    std::cout << "[\"MedianFinder\", \"addNum\", \"addNum\", \"findMedian\", \"addNum\", \"findMedian\"]" << std::endl;
    std::cout << "[[], [1], [2], [], [3], []]" << std::endl;

    std::cout << "Output" << std::endl;

    std::vector<std::string> outputList;

    outputList.push_back("null"); // Output of MedianFinder constructor

    outputList.push_back("null"); // Output of AddNum(1)
    medianFinder.addNum(1);

    outputList.push_back("null"); // Output of AddNum(2)
    medianFinder.addNum(2);

    outputList.push_back(std::to_string(medianFinder.findMedian())); // Output of FindMedian()

    outputList.push_back("null"); // Output of AddNum(3)
    medianFinder.addNum(3);

    outputList.push_back(std::to_string(medianFinder.findMedian())); // Output of FindMedian()

    std::cout << "[" << join(", ", outputList) << "]" << std::endl;

    return 0;
}