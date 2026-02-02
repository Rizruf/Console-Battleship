# Console Battleship (Морской Бой)

Классическая игра "Морской Бой", написанная на **C#** с упором на чистую архитектуру и принципы ООП.
Проект реализует полноценный игровой цикл: расстановка кораблей, стрельба, логика бота и система "Тумана Войны".


![.NET](https://img.shields.io/badge/.NET-9.0-512BD4?style=flat&logo=dotnet)
![C#](https://img.shields.io/badge/C%23-100%25-239120?style=flat&logo=c-sharp)
![Architecture](https://img.shields.io/badge/Architecture-Layered-blueviolet)
![License](https://img.shields.io/badge/License-MIT-blue)

## Основные фичи (Key Features)

*   **Архитектура:** Четкое разделение на слои (Entities, GameEngine, UI).
*   **OOP Design:** Использование Полиморфизма (`Player` -> `Human/Bot`) и Инкапсуляции.
*   **Smart Rendering:** Система отрисовки консоли с поддержкой цветов и скрытия вражеских кораблей ("Туман Войны").
*   **Game Logic:**
    *   Валидация расстановки (корабли не накладываются и соблюдают дистанцию).
    *   Умный подсчет попаданий и определение потопления (`IsSunk`).
*   **Bot AI:** Реализован компьютерный противник с автоматической расстановкой флота.

## Технический стек (Tech Stack)

*   **Language:** C# 12
*   **Platform:** .NET 9
*   **Tools:** Git CLI, Visual Studio 2022
*   **Concepts:** `Enums`, `Structs`, `Extension Methods`, `LINQ`.

## Как запустить

1.  Клонируйте репозиторий:
    ```bash
    git clone https://github.com/Rizruf/Console-Battleship.git
    ```
2.  Откройте `BattleshipGame.sln` в Visual Studio.
3.  Нажмите **F5** (Run).
