

# SOLID Principles – Summary

## Introduction

**SOLID** is a set of five software design principles that help developers write code that is:

- Maintainable
- Reusable
- Flexible
- Easy to test
- Easy to extend

The five principles are:

1. **S** – Single Responsibility Principle (SRP)
2. **O** – Open/Closed Principle (OCP)
3. **L** – Liskov Substitution Principle (LSP)
4. **I** – Interface Segregation Principle (ISP)
5. **D** – Dependency Inversion Principle (DIP)

---

## 1. Single Responsibility Principle (SRP)

**A class should have only one reason to change.**

A class should have one responsibility, not multiple unrelated responsibilities.

### Example

Instead of putting everything inside one `Employee` class:

```csharp
public class Employee
{
    public void Save() { }
    public void GenerateReport() { }
}
```

Separate responsibilities:

```csharp
public class Employee
{
    public string Name { get; set; }
}

public class EmployeeRepository
{
    public void Save(Employee employee) { }
}

public class EmployeeReport
{
    public void Generate(Employee employee) { }
}
```

**Key Idea:** Each class should focus on one responsibility.

---

## 2. Open/Closed Principle (OCP)

**Software entities should be open for extension but closed for modification.**

We should be able to add new functionality without modifying existing, stable code.

### Example

Instead of modifying a discount method every time we add a new discount type:

```csharp
public interface IDiscount
{
    decimal ApplyDiscount(decimal price);
}
```

Different implementations:

```csharp
public class StudentDiscount : IDiscount
{
    public decimal ApplyDiscount(decimal price)
        => price * 0.9m;
}

public class PremiumDiscount : IDiscount
{
    public decimal ApplyDiscount(decimal price)
        => price * 0.8m;
}
```

Now we can introduce new discount types without changing the existing implementations.

**Key Idea:** Extend behavior through abstractions and new implementations instead of repeatedly modifying existing code.

---

## 3. Liskov Substitution Principle (LSP)

**Objects of a base class should be replaceable with objects of its derived classes without breaking the program.**

A derived class must respect the expected behavior of its base class.

### Example

A problematic design:

```csharp
public class Bird
{
    public virtual void Fly() { }
}

public class Penguin : Bird
{
    public override void Fly()
    {
        throw new Exception("Penguins cannot fly!");
    }
}
```

The problem is that `Penguin` cannot correctly fulfill the expected behavior of `Bird.Fly()`.

A better design:

```csharp
public class Bird
{
}

public interface IFlyable
{
    void Fly();
}

public class Eagle : Bird, IFlyable
{
    public void Fly() { }
}

public class Penguin : Bird
{
}
```

**Key Idea:** Inheritance should preserve expected behavior. Don't force subclasses to implement behavior they cannot support.

---

## 4. Interface Segregation Principle (ISP)

**Clients should not be forced to depend on methods they do not use.**

Prefer small, specific interfaces instead of one large interface containing unrelated methods.

### Example

A problematic interface:

```csharp
public interface IWorker
{
    void Work();
    void Eat();
}
```

Not every worker necessarily needs an `Eat()` implementation.

A better design:

```csharp
public interface IWorkable
{
    void Work();
}

public interface IEatable
{
    void Eat();
}
```

Now each class implements only the interfaces it actually needs.

**Key Idea:** Keep interfaces small and focused.

---

## 5. Dependency Inversion Principle (DIP)

**High-level modules should not depend on low-level modules. Both should depend on abstractions.**

Instead of making a class depend directly on a concrete implementation, make it depend on an interface or abstraction.

### Example

Define an abstraction:

```csharp
public interface IOrderRepository
{
    void Save();
}
```

Implement it:

```csharp
public class SqlOrderRepository : IOrderRepository
{
    public void Save() { }
}
```

Use the abstraction in the high-level class:

```csharp
public class OrderService
{
    private readonly IOrderRepository _repository;

    public OrderService(IOrderRepository repository)
    {
        _repository = repository;
    }

    public void CreateOrder()
    {
        _repository.Save();
    }
}
```

Now `OrderService` doesn't depend directly on SQL Server or a specific repository implementation.

**Key Idea:** Depend on abstractions, not concrete classes.

---

## Quick Revision

| Principle | Main Idea |
|---|---|
| SRP | One class, one responsibility |
| OCP | Extend without modifying existing code |
| LSP | Derived classes must be substitutable for their base classes |
| ISP | Prefer small, focused interfaces |
| DIP | Depend on abstractions, not concrete implementations |

## How to Remember SOLID

- **SRP:** One responsibility.
- **OCP:** Extend, don't modify.
- **LSP:** Subclasses must behave correctly.
- **ISP:** Small interfaces.
- **DIP:** Depend on abstractions.

