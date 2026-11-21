# Dependency Inversion Principle (DIP) vs Dependency Injection (DI)

## 1. Dependency يعني إيه؟

A **Dependency** هي كلاس أو خدمة كلاس آخر محتاجها علشان ينفذ وظيفته.

مثال:

```csharp
public class ReportGenerator
{
    private PdfReport _pdfReport;

    public ReportGenerator()
    {
        _pdfReport = new PdfReport();
    }

    public void Generate()
    {
        _pdfReport.Generate();
    }
}
```

هنا `ReportGenerator` يعتمد على `PdfReport` بشكل مباشر؛ لأنه ينشئه بنفسه باستخدام `new`.

- `ReportGenerator`: Dependent Class / High-Level Module.
- `PdfReport`: Dependency / Low-Level Module.
- العلاقة المباشرة دي بتسبب **Tight Coupling**.

لو احتجنا ندعم HTML بدل PDF، هنضطر نعدل `ReportGenerator` أو نضيف له منطق خاص بكل نوع تقرير.

---

## 2. Dependency Inversion Principle (DIP)

DIP هو أحد مبادئ **SOLID**، وبيهدف إلى تقليل الاعتماد المباشر بين الـ High-Level Modules والـ Low-Level Modules.

المبدأ له قاعدتان:

1. High-level modules should not depend on low-level modules. Both should depend on abstractions.
2. Abstractions should not depend on details. Details should depend on abstractions.

بمعنى:

- **High-Level Module:** يحتوي عادةً على Business Logic، مثل `ReportGenerator`.
- **Low-Level Module:** ينفذ تفاصيل تقنية، مثل `PdfReport` أو التعامل مع Database.
- **Abstraction:** عقد عام مثل Interface أو Abstract Class.

### تطبيق DIP

بدل ما `ReportGenerator` يعتمد على `PdfReport`، نخليه يعتمد على Interface اسمها `IReport`.

```csharp
public interface IReport
{
    void Generate();
}
```

كل نوع تقرير ينفذ الـ Interface:

```csharp
public class PdfReport : IReport
{
    public void Generate()
    {
        Console.WriteLine("Generating PDF Report...");
    }
}

public class HtmlReport : IReport
{
    public void Generate()
    {
        Console.WriteLine("Generating HTML Report...");
    }
}
```

والـ High-Level Module يعتمد على الـ Abstraction:

```csharp
public class ReportGenerator
{
    private readonly IReport _report;

    public ReportGenerator(IReport report)
    {
        _report = report;
    }

    public void Generate()
    {
        _report.Generate();
    }
}
```

الآن `ReportGenerator` لا يعرف هل التنفيذ PDF أو HTML. هو يعرف فقط `IReport`.

لإضافة نوع جديد مثل Excel، ننشئ `ExcelReport : IReport` دون الحاجة إلى تعديل `ReportGenerator`.

**الفكرة الأساسية في DIP:** اعتمد على Abstractions بدل Concrete Implementations.

> ملاحظة: استخدام Interface وحده لا يضمن تطبيق DIP. المهم أن يكون اتجاه الاعتماديات صحيحًا، وألا يعتمد الـ High-Level Module مباشرة على تفاصيل التنفيذ.

---

## 3. Dependency Injection (DI)

**Dependency Injection** هي Technique / Design Pattern لتوفير الـ Dependencies للكلاس من الخارج بدل ما الكلاس ينشئها بنفسه.

بدل أن يقول `ReportGenerator`:

> سأُنشئ PdfReport بنفسي.

يقول:

> أنا أحتاج Object يحقق IReport؛ وفّره لي من الخارج.

مثال Constructor Injection:

```csharp
IReport report = new PdfReport();

ReportGenerator generator = new ReportGenerator(report);

generator.Generate();
```

ولو أردنا HTML:

```csharp
IReport report = new HtmlReport();

ReportGenerator generator = new ReportGenerator(report);

generator.Generate();
```

لم نغيّر `ReportGenerator`؛ فقط مررنا له Implementation مختلفة.

---

## 4. أنواع Dependency Injection

### A. Constructor Injection

يتم تمرير الـ Dependency من خلال Constructor.

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

- الأكثر شيوعًا وتوصيةً.
- مناسب للـ Dependencies الأساسية التي لا يستطيع الكلاس العمل بدونها.
- يجعل الاعتماديات واضحة عند إنشاء الـ Object.

### B. Property Injection

يتم تمرير الـ Dependency من خلال Property.

```csharp
public class ReportGenerator
{
    public IReport Report { get; set; }

    public void Generate()
    {
        Report.Generate();
    }
}
```

الاستخدام:

```csharp
var generator = new ReportGenerator();
generator.Report = new PdfReport();
generator.Generate();
```

العيب: يمكن نسيان تعيين الـ Property، وبالتالي قد يحدث `NullReferenceException`.

### C. Method Injection

يتم تمرير الـ Dependency كـ Parameter للـ Method.

```csharp
public class ReportGenerator
{
    public void Generate(IReport report)
    {
        report.Generate();
    }
}
```

مناسب عندما تكون الـ Dependency مطلوبة لعملية معينة فقط، وليس لكل وظائف الكلاس.

---

## 5. مثال عملي: Notification في E-Commerce

لنفترض أن `OrderService` يحتاج إلى إرسال إشعار بعد إنشاء الطلب.

بدل الاعتماد المباشر على `EmailService`، ننشئ Abstraction:

```csharp
public interface INotificationService
{
    void Send();
}
```

Implementations:

```csharp
public class EmailService : INotificationService
{
    public void Send()
    {
        Console.WriteLine("Sending Email...");
    }
}

public class SmsService : INotificationService
{
    public void Send()
    {
        Console.WriteLine("Sending SMS...");
    }
}
```

Business Logic:

```csharp
public class OrderService
{
    private readonly INotificationService _notification;

    public OrderService(INotificationService notification)
    {
        _notification = notification;
    }

    public void CreateOrder()
    {
        // Create order business logic

        _notification.Send();
    }
}
```

`OrderService` لا يحتاج إلى معرفة طريقة إرسال الإشعار. يمكن تمرير `EmailService` أو `SmsService` أو أي Implementation أخرى لـ `INotificationService`.

---

## 6. DI Container في ASP.NET Core

ASP.NET Core يحتوي على Built-in Dependency Injection Container.

نسجل العلاقة بين الـ Interface والـ Implementation في `Program.cs`:

```csharp
builder.Services.AddScoped<INotificationService, EmailService>();
builder.Services.AddScoped<OrderService>();
```

عندما يحتاج ASP.NET Core إلى إنشاء `OrderService`، فإنه:

1. يقرأ الـ Constructor ويجد أنه يحتاج `INotificationService`.
2. يبحث في Service Container عن Implementation مسجلة لهذا الـ Interface.
3. يجد `EmailService`.
4. ينشئها ويمررها إلى `OrderService`.

هذا يسمى **Automatic Dependency Resolution**.

### Service Lifetimes

| Lifetime | المعنى |
|---|---|
| Transient | Instance جديدة مع كل مرة يتم فيها طلب الخدمة من الـ Container. |
| Scoped | Instance واحدة داخل نفس HTTP Request. |
| Singleton | Instance واحدة طوال عمر التطبيق. |

ملاحظات:
- `AddTransient<TService, TImplementation>()`
- `AddScoped<TService, TImplementation>()`
- `AddSingleton<TService, TImplementation>()`
- `DbContext` يُسجل عادةً كـ Scoped باستخدام `AddDbContext`.
- تجنب حقن Scoped Service مباشرةً داخل Singleton؛ لأن ذلك قد يسبب مشكلة Captive Dependency.

---

## 7. الفرق بين DIP و DI

| DIP | DI |
|---|---|
| Dependency Inversion Principle | Dependency Injection |
| مبدأ من SOLID | Technique / Design Pattern |
| يحدد كيف يجب أن تعتمد الكلاسات على بعضها | يحدد كيف تستقبل الكلاسات Dependencies |
| يجعل الاعتماد على Abstractions بدل التفاصيل | يمرر Dependencies من الخارج |
| يركز على Structure and Direction of Dependencies | يركز على Providing Dependencies |

### تذكّر

- **DIP:** How should classes depend on each other?
- **DI:** How should a class receive its dependencies?

DI تساعد على تطبيق DIP، لكنها ليست الطريقة الوحيدة. ويمكن تطبيق DIP يدويًا دون استخدام DI Container أو Framework.

---

## 8. أهم المصطلحات

- **Dependency:** كلاس أو خدمة يعتمد عليها كلاس آخر.
- **Tight Coupling:** ارتباط قوي ومباشر بين الكلاسات.
- **Loose Coupling:** تقليل الاعتماد المباشر بين الكلاسات.
- **Abstraction:** عقد عام يمثله غالبًا Interface أو Abstract Class.
- **Concrete Implementation:** كلاس يقدم التنفيذ الفعلي.
- **Dependency Injection:** تمرير الـ Dependencies من الخارج.
- **DI Container:** أداة تنشئ الخدمات وتحل الاعتماديات وتدير أعمارها.

## الخلاصة

**DIP is a design principle; DI is a technique/pattern.**

- DIP يوجّه تصميم النظام للاعتماد على Abstractions بدل Concrete Implementations.
- DI توفر الـ Dependencies للكلاسات من الخارج بدل إنشائها داخلها.
- Constructor Injection هي الطريقة الأكثر شيوعًا.
- ASP.NET Core يوفر Built-in DI Container لإدارة الخدمات تلقائيًا.
- النتيجة المطلوبة هي تقليل Coupling، وتسهيل التغيير والاختبار والصيانة.
