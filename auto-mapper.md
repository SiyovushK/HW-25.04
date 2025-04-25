## EF Core Homework Task

### 📘 Основные темы:
- **EF Core** (Entity Framework Core)
- **LINQ**
- **AutoMapper**
- **Fluent API**
- **Data Annotations**

---

## 🗃️ Требования к структуре базы данных (4–5 таблиц):

1. **Students (Студенты):**
   - `StudentId` (PK)
   - `FirstName` (обязательное)
   - `LastName` (обязательное)
   - `BirthDate`

2. **Courses (Курсы):**
   - `CourseId` (PK)
   - `Title` (обязательное)
   - `Description`
   - `Price`

3. **Enrollments (Записи на курсы):** *(Many-to-Many между Students и Courses)*
   - `EnrollmentId` (PK)
   - `StudentId` (FK)
   - `CourseId` (FK)
   - `EnrollDate`
   - `Grade`

4. **Instructors (Преподаватели):**
   - `InstructorId` (PK)
   - `FirstName`
   - `LastName`
   - `Phone`

5. **CourseAssignments (Назначения курсов):** *(One-to-Many между Instructors и Courses)*
   - `CourseAssignmentId` (PK)
   - `CourseId` (FK)
   - `InstructorId` (FK)

---

## 🔨 Задачи:

### 1. Реализация CRUD-операций:
- Реализовать CRUD для всех таблиц через EF Core.

### 2. Конфигурация моделей:
- Использовать **Fluent API**.
- Использовать **Data Annotations**.

### 3. Настройка AutoMapper:
- Настроить маппинг между DTO и сущностями для моделей `Student`, `Course`, `Instructor`.

### 4. LINQ-запросы:
- Написать 5 запросов статистики:
  1. Количество студентов на каждом курсе.
  2. Средняя оценка по каждому курсу.
  3. Количество курсов, на которые записался каждый студент.
  4. Студенты, не записанные ни на один курс.
  5. Список преподавателей и количество курсов, которые они ведут.

---

## ✅ Ожидаемый результат:
- Реализованная модель данных.
- Корректные миграции и база данных.
- Рабочие CRUD-эндпоинты.
- LINQ-запросы, возвращающие корректную статистику.
- Настроенный AutoMapper.
- Применение Fluent API и Data Annotations согласно заданию.

---

Убедитесь, что вы проверили корректность связей, ограничений и использовали принципы чистого кода. Все запросы можно проверять через Swagger.

