#pragma once
#define DllExport __declspec(dllexport)

extern "C" DllExport bool IsEven(int a);
