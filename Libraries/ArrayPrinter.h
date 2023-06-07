#ifndef ARRAYPRINTER_H
#define ARRAYPRINTER_H

#include <iostream>
#include <vector>

// Función para imprimir un vector
template <typename T>
void printArray(const std::vector<T> &array)
{
    // El nombre N es solo una convención
    std::cout << "Input: nums = [";
    for(int i = 0; i < array.size(); ++i)
    {
        std::cout << array[i];
        if(i != array.size() - 1)
            std::cout << ", ";
    }
    std::cout << "]"<< std::endl;
}

// Función para imprimir un vector y un target
template <typename T>
void printInput(const std::vector<T> &array, int target)
{
    // El nombre N es solo una convención
    std::cout << "Input: nums = [";
    for(int i = 0; i < array.size(); ++i)
    {
        std::cout << array[i];
        if(i != array.size() - 1)
            std::cout << ", ";
    }
    std::cout << "], target = " << target << std::endl;
}

// Función para imprimir un vector
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

// Función para imprimir un vector de vectores
template <typename T>
void printVV(const std::vector<std::vector<T>> &array)
{
    std::cout << "Output: [";
    for(int i = 0; i < array.size(); i++)
    {
        std::cout << "[";
        for(int j = 0; j < array[i].size(); j++)
        {
            std::cout << array[i][j];
            if(j != array[i].size() - 1)
                std::cout << ", ";
        }
        std::cout << "]";
        if(i != array.size() - 1)
            std::cout << ", ";
    }
    std::cout << "]"<< std::endl;
}

#endif