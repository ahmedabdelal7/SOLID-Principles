

# SOLID Principles – Course Summary

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

# 1. Single Responsibility Principle (SRP)

### Definition

**A class should have only one reason to change.**

A class should have one responsibility, meaning it should focus on one specific task.

If a class handles multiple unrelated responsibilities, changes in one responsibility may affect the others.

### Example 1: Notification Service

Imagine a `NotificationService` class responsible for:

- Creating notification messages.
- Sending notifications.
- Logging notification details.

This class has multiple responsibilities.

A better design is to separate these responsibilities:

```csharp
public class NotificationService
{
    public void SendNotification(string message)
    {
        // Send notification
    }
}

public class NotificationLogger
{
    public void LogNotification(string message)
    {
        // Log notification details
    }
}
```

Now each class has a specific responsibility.

### Example 2: Logging Service

Imagine a `LoggingService` class that handles:

- Creating log messages.
- Saving logs to a file.
- Saving logs to a database.
- Displaying logs.

These responsibilities can be separated into different classes.

For example:

- `LoggingService`: Coordinates logging.
- `FileLogger`: Saves logs to files.
- `DatabaseLogger`: Saves logs to a database.

### Key Idea

**One class = One responsibility = One reason to change.**

Don't create a class that does everything.

---

# 2. Open/Closed Principle (OCP)

### Definition

**Software entities should be open for extension but closed for modification.**

We should be able to add new functionality without modifying existing, stable code.

### Example 1: Notification Service

Imagine a notification system that initially supports Email notifications.

A simple implementation might look like this:

```csharp
public class NotificationService
{
    public void Send(string type, string message)
    {
        if (type == "Email")
        {
            // Send Email
        }
        else if (type == "SMS")
        {
            // Send SMS
        }
    }
}
```

The problem:

Every time we add a new notification type, such as WhatsApp, we must modify the existing class.

This violates OCP.

### Better Design

Create an abstraction:

```csharp
public interface INotificationService
{
    void Send(string message);
}
```

Implement different notification types:

```csharp
public class EmailNotification : INotificationService
{
    public void Send(string message)
    {
        // Send Email
    }
}

public class SMSNotification : INotificationService
{
    public void Send(string message)
    {
        // Send SMS
    }
}
```

Now we can add `WhatsAppNotification` without modifying the existing implementations.

### Example 2: Logging Service

Suppose a logging system initially saves logs to a file.

Later, we want to support:

- Database Logging.
- Console Logging.
- Cloud Logging.

Instead of modifying the existing logging logic every time, we can introduce an abstraction such as `ILogger` and create different implementations.

### Example 3: Payment Service

Imagine a payment system that supports:

- Credit Card.
- PayPal.
- Cash.

Instead of using multiple `if/else` conditions inside one payment class, we can define:

```csharp
public interface IPaymentService
{
    void Pay(decimal amount);
}
```

Then create separate implementations:

```csharp
public class CreditCardPayment : IPaymentService
{
    public void Pay(decimal amount)
    {
        // Process Credit Card payment
    }
}

public class PayPalPayment : IPaymentService
{
    public void Pay(decimal amount)
    {
        // Process PayPal payment
    }
}

public class CashPayment : IPaymentService
{
    public void Pay(decimal amount)
    {
        // Process Cash payment
    }
}
```

Adding a new payment method doesn't require modifying the existing payment implementations.

### Key Idea

**Extend behavior without modifying existing code.**

Use abstractions and polymorphism to make your system extensible.

---

# 3. Liskov Substitution Principle (LSP)

### Definition

**Objects of a base class should be replaceable with objects of its derived classes without breaking the program.**

A derived class must respect the expected behavior of its base class.

### Example 1: Bird

Imagine we have a base class:

```csharp
public class Bird
{
    public virtual void Fly()
    {
        Console.WriteLine("Bird is flying");
    }
}
```

And a derived class:

```csharp
public class Penguin : Bird
{
    public override void Fly()
    {
        throw new NotImplementedException();
    }
}
```

The problem:

A penguin cannot fly, so it cannot correctly fulfill the expected behavior of `Bird.Fly()`.

Using `Penguin` wherever a flying `Bird` is expected may break the program.

### Better Design

Separate flying behavior:

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
    public void Fly()
    {
        Console.WriteLine("Eagle is flying");
    }
}

public class Penguin : Bird
{
}
```

Now a penguin is still a bird, but it is not forced to implement flying behavior.

### Example 2: Vehicle

Consider a base `Vehicle` class that defines a behavior such as `StartEngine()`.

If we create a derived class representing an electric vehicle that doesn't have the expected engine behavior, we must reconsider the inheritance design.

The derived class should not break the assumptions made by code that works with the base class.

### Example 3: Person

The same principle applies to inheritance involving people.

If a base class defines certain expected behaviors, every derived class must preserve those expectations.

A derived class should not unexpectedly reject valid operations or change their meaning.

### Key Idea

**Inheritance should preserve behavior, not just share properties.**

A subclass must be a valid substitute for its base class.

---

# 4. Interface Segregation Principle (ISP)

### Definition

**Clients should not be forced to depend on methods they do not use.**

Instead of creating one large interface containing many unrelated methods, create smaller, specific interfaces.

### Example 1: Printer

Imagine a printer interface:

```csharp
public interface IPrinter
{
    void Print();
    void Scan();
    void Fax();
}
```

Now imagine a simple printer that only supports printing.

It will be forced to implement `Scan()` and `Fax()` even though it doesn't support them.

This violates ISP.

### Better Design

Split the interface:

```csharp
public interface IPrinter
{
    void Print();
}

public interface IScanner
{
    void Scan();
}

public interface IFax
{
    void Fax();
}
```

Now each device implements only the functionality it supports.

A simple printer:

```csharp
public class SimplePrinter : IPrinter
{
    public void Print()
    {
        // Print document
    }
}
```

A multifunction printer:

```csharp
public class MultiFunctionPrinter : IPrinter, IScanner, IFax
{
    public void Print() { }
    public void Scan() { }
    public void Fax() { }
}
```

### Example 2: Payment

Imagine a payment interface containing multiple operations:

- Pay.
- Refund.
- Installments.

Not every payment method necessarily supports all these operations.

We can split the interface into smaller interfaces:

```csharp
public interface IPayable
{
    void Pay(decimal amount);
}

public interface IRefundable
{
    void Refund(decimal amount);
}

public interface IInstallmentPayment
{
    void PayInInstallments(decimal amount);
}
```

Each payment implementation can choose the capabilities it supports.

### Example 3: Device

Imagine different devices with different capabilities.

A device might support:

- Power On.
- Power Off.
- Connect to Wi-Fi.
- Bluetooth.

Not every device supports every feature.

Instead of forcing all devices to implement one large interface, separate the capabilities into smaller interfaces.

### Interface Inheritance

An interface can inherit from another interface.

For example:

```csharp
public interface IPrinter
{
    void Print();
}

public interface IScanner
{
    void Scan();
}

public interface IMultiFunctionDevice : IPrinter, IScanner
{
}
```

Any class implementing `IMultiFunctionDevice` must implement the methods inherited from both interfaces.

### Key Idea

**Small and focused interfaces are better than large interfaces.**

A class should only implement the functionality it actually needs.

---

# 5. Dependency Inversion Principle (DIP)

### Definition

**High-level modules should not depend on low-level modules. Both should depend on abstractions.**

Abstractions should not depend on details. Details should depend on abstractions.

### Example 1: Report

Imagine we have a `ReportGenerator` class that directly depends on `PdfReport`.

```csharp
public class PdfReport
{
    public void Generate()
    {
        Console.WriteLine("Generating PDF Report");
    }
}

public class ReportGenerator
{
    private PdfReport _report = new PdfReport();

    public void GenerateReport()
    {
        _report.Generate();
    }
}
```

The problem:

`ReportGenerator` is tightly coupled to `PdfReport`.

If we want to generate an HTML or Excel report, we need to modify `ReportGenerator`.

This makes the system difficult to extend and test.

### Better Design

Introduce an abstraction:

```csharp
public interface IReport
{
    void Generate();
}
```

Implement different report types:

```csharp
public class PdfReport : IReport
{
    public void Generate()
    {
        Console.WriteLine("Generating PDF Report");
    }
}

public class HtmlReport : IReport
{
    public void Generate()
    {
        Console.WriteLine("Generating HTML Report");
    }
}
```

Now the high-level class depends on the abstraction:

```csharp
public class ReportGenerator
{
    private readonly IReport _report;

    public ReportGenerator(IReport report)
    {
        _report = report;
    }

    public void GenerateReport()
    {
        _report.Generate();
    }
}
```

Now `ReportGenerator` doesn't need to know whether it is working with PDF, HTML, or another report type.

### Key Idea

**Depend on abstractions, not concrete implementations.**

This reduces tight coupling and makes the system easier to extend and test.

---

# 6. Dependency Inversion Principle (DIP) vs Dependency Injection (DI)

These two concepts are related, but they are not the same.

## Dependency Inversion Principle (DIP)

DIP is a **design principle**.

It tells us how to structure dependencies:

- High-level modules depend on abstractions.
- Low-level modules depend on abstractions.
- Avoid direct dependencies between high-level and low-level modules.

## Dependency Injection (DI)

DI is a **design pattern / technique** used to provide a class with its dependencies from outside instead of letting the class create them itself.

For example:

```csharp
public class ReportGenerator
{
    private readonly IReport _report;

    public ReportGenerator(IReport report)
    {
        _report = report;
    }
}
```

Here, the dependency is provided through the constructor. This is called **Constructor Injection**.

Other injection methods include:

- Constructor Injection.
- Property Injection.
- Method Injection.

## The Difference

| DIP | DI |
|---|---|
| Design Principle | Design Pattern / Technique |
| Defines how dependencies should be structured | Provides dependencies from outside |
| Focuses on abstractions | Focuses on supplying dependencies |
| Reduces tight coupling | Helps implement loose coupling |

**Important:** DI is one way to help implement DIP, but following DIP doesn't necessarily mean using a DI container.

---

# Final Revision

| Principle | Main Idea | Course Example |
|---|---|---|
| SRP | One class, one responsibility | Notification Service / Logging Service |
| OCP | Extend without modifying existing code | Notification / Logging / Payment |
| LSP | Derived classes must preserve expected behavior | Bird / Vehicle / Person |
| ISP | Don't force classes to implement unused methods | Printer / Payment / Device |
| DIP | Depend on abstractions, not concrete classes | Report |

## Remember SOLID

- **SRP:** One responsibility.
- **OCP:** Open for extension, closed for modification.
- **LSP:** Subclasses must be substitutable.
- **ISP:** Small, focused interfaces.
- **DIP:** Depend on abstractions.

