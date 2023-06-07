#ifndef ARRAYPRINTER_H
#define ARRAYPRINTER_H

#include <iostream>
#include <vector>

template <typename T>
void printArray(const std::vector<T> &array)
{
    // El nombre T es solo una convención
    std::cout << "Input: T = [";
    for(int i = 0; i < array.size(); ++i)
    {
        std::cout << array[i];
        if(i != array.size() - 1)
            std::cout << ", ";
    }
    std::cout << "]"<< std::endl;
}

template <typename T>
void printInput(const std::vector<T> &array, int target)
{
    std::cout << "Input: Nums =[";
    for(int i = 0; i < array.size(); ++i)
    {
        std::cout << array[i];
        if(i != array.size() - 1)
            std::cout << ", ";
    }
    std::cout << "], target = " << target << std::endl;
}

template <typename T>
void printOutput(const std::vector<T> &array)
{
    std::cout << "Output: [";
    for(int i = 0; i < array.size(); i++)
    {
        std::cout << array[i];
        if(i != array.size() - 1)
            std::cout << ", ";
    }
    std::cout << "]"<< std::endl;
}

#endif