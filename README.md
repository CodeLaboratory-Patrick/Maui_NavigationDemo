# Navigating Between Pages in .NET MAUI

## Overview
In **.NET MAUI**, navigating between pages is essential to provide a seamless user experience. There are various ways to navigate between pages, each serving specific purposes depending on the application's needs. The navigation methods covered include **PushAsync**, **PopAsync**, **PushModalAsync**, **PopModalAsync**, and **GoToAsync**. These methods help in managing different navigation flows, such as hierarchical navigation and modal navigation.

### Types of Navigation in .NET MAUI
1. **PushAsync**: Adds a new page to the navigation stack.
2. **PopAsync**: Removes the current page from the navigation stack.
3. **PushModalAsync**: Adds a new page as a modal overlay.
4. **PopModalAsync**: Closes the modal page.
5. **GoToAsync**: Uses **Shell** to navigate between pages with URI-based routing.

## 1. PushAsync
**PushAsync** is used to navigate to a new page by adding it to the **NavigationStack**. It is primarily used in applications with a hierarchical navigation structure, where users can move forward and backward between pages.

### Key Features
- **Adds Page to Stack**: Pushes a new page onto the **NavigationStack**.
- **Hierarchical Navigation**: Best suited for scenarios where users navigate through levels of content (e.g., navigating from a list to a detail view).
- **Asynchronous Method**: It is an async method, allowing for proper handling of UI responsiveness.

### Example
```csharp
public partial class MainPage : ContentPage
{
    public MainPage()
    {
        InitializeComponent();
    }

    private async void NavigateButton_Clicked(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new SecondPage());
    }
}
```
- **PushAsync**: Adds the `SecondPage` to the navigation stack.

### When to Use
- **Hierarchical Navigation**: When you need users to navigate through multiple levels in an application, such as navigating from a product list to a product detail.
- **Forward Navigation**: When a user action requires showing new content that allows backtracking.

## 2. PopAsync
**PopAsync** is used to remove the current page from the **NavigationStack**, effectively navigating back to the previous page.

### Key Features
- **Removes Page from Stack**: Pops the current page off the stack, navigating to the previous page.
- **Back Navigation**: Typically used for back navigation within a stack of pages.
- **Asynchronous Method**: Ensures UI remains responsive by awaiting the operation.

### Example
```csharp
private async void BackButton_Clicked(object sender, EventArgs e)
{
    await Navigation.PopAsync();
}
```
- **PopAsync**: Removes the current page from the stack and navigates back to the previous page.

### When to Use
- **Back Navigation**: When the user needs to return to the previous page, such as returning to a list after viewing an item’s details.

## 3. PushModalAsync
**PushModalAsync** is used to present a page as a modal overlay. This method is ideal for cases where user interaction must be completed before continuing.

### Key Features
- **Modal Overlay**: Displays the page as a full-screen modal, blocking interaction with previous pages until dismissed.
- **Separate Stack**: Modal pages are maintained in a separate stack, allowing for focused user tasks.

### Example
```csharp
private async void ShowModalButton_Clicked(object sender, EventArgs e)
{
    await Navigation.PushModalAsync(new ModalPage());
}
```
- **PushModalAsync**: Presents `ModalPage` as a modal overlay.

### When to Use
- **Focused User Tasks**: When an interaction, such as a form submission or user agreement, must be completed before proceeding.
- **Full-Screen Prompts**: Ideal for login screens, pop-up dialogs, or any scenario requiring focused user input.

## 4. PopModalAsync
**PopModalAsync** is used to dismiss the current modal page, removing it from the modal stack.

### Key Features
- **Dismiss Modal**: Closes the top-most modal page on the modal stack.
- **Return to Previous Page**: Navigates back to the page beneath the modal overlay.

### Example
```csharp
private async void CloseModalButton_Clicked(object sender, EventArgs e)
{
    await Navigation.PopModalAsync();
}
```
- **PopModalAsync**: Closes the modal page and returns to the underlying page.

### When to Use
- **Closing Modal Pages**: When the user has completed an action in a modal page, such as finishing a form.

## 5. GoToAsync
**GoToAsync** is used with **Shell** navigation in .NET MAUI, allowing for URI-based navigation to different routes in the application.

### Key Features
- **URI-Based Navigation**: Uses a URI scheme to navigate between pages, making it easy to navigate to specific routes within the app.
- **Shell Integration**: Best used with applications built using **Shell**, which offers a unified navigation structure, including flyouts and tabs.
- **Parameter Passing**: Allows passing parameters directly in the URI for more flexible navigation.

### Example
```csharp
private async void NavigateToDetailPage_Clicked(object sender, EventArgs e)
{
    await Shell.Current.GoToAsync("//DetailPage");
}
```
- **GoToAsync**: Navigates to the `DetailPage` using a URI-based approach.

### When to Use
- **Complex Navigation**: When using **Shell** for navigation in large applications with multiple sections.
- **Deep Linking**: Ideal for apps requiring deep linking or direct navigation to specific routes based on user input or external triggers.

## Comparison of Navigation Methods
| Navigation Method      | Description                                    | Use Case                                        |
|------------------------|------------------------------------------------|-------------------------------------------------|
| **PushAsync**          | Adds a page to the **NavigationStack**         | Forward navigation through hierarchical flows   |
| **PopAsync**           | Removes the current page from the stack       | Back navigation to a previous page              |
| **PushModalAsync**     | Presents a page as a modal                    | Forms, login screens, focused interactions      |
| **PopModalAsync**      | Dismisses the current modal page              | Closing modal forms or dialogs                  |
| **GoToAsync**          | URI-based navigation using **Shell**          | Tab/flyout-based apps, deep linking, complex flows |

## Commonalities
- **Asynchronous Methods**: All methods are asynchronous (`await`), ensuring that navigation actions do not block the UI thread.
- **Page Navigation**: All methods are used for moving between pages, but they vary in how the pages are managed.

## Practical Scenario
Consider a booking app for travel:
- **PushAsync** and **PopAsync** can be used to navigate through the booking process, moving from selecting a destination to selecting dates and then confirming booking details.
- **PushModalAsync** can be used for presenting a login form that must be filled before proceeding with the booking.
- **GoToAsync** can be used with **Shell** for direct navigation to sections like **Flights**, **Hotels**, or **Profile**, utilizing URI-based navigation for deep linking.

## Reference Sites
- [.NET MAUI Documentation](https://learn.microsoft.com/en-us/dotnet/maui/)
- [Microsoft Learn - NavigationPage](https://learn.microsoft.com/en-us/dotnet/maui/fundamentals/navigation)
- [Shell Navigation in .NET MAUI](https://learn.microsoft.com/en-us/dotnet/maui/fundamentals/shell/navigation)

# Examining the Navigation Stack in .NET MAUI

## Overview
In **.NET MAUI**, navigation stacks are used to manage the pages that a user has visited, allowing for seamless forward and backward navigation through the app. By examining the **NavigationStack** and **ModalStack**, developers can control the flow of pages in their application and manage the user experience efficiently. Additionally, **PopToRootAsync** is a method that allows developers to return the user to the root page of the navigation stack.

### Key Navigation Stack Elements
1. **NavigationStack**: A stack of pages managed by `NavigationPage` to handle hierarchical navigation.
2. **ModalStack**: A separate stack of pages for managing modal navigation overlays.
3. **PopToRootAsync**: A method to clear all the pages from the navigation stack except the root page, effectively navigating back to the root.

## 1. NavigationStack
The **NavigationStack** refers to the list of pages that have been pushed onto the **NavigationPage**. It allows for forward and backward navigation similar to a web browser, where pages are pushed onto or popped from the stack.

### Key Features
- **Hierarchical Navigation**: Pages are stacked in the order they are visited, with the most recent page at the top.
- **Access to Stack**: You can access the **NavigationStack** to get information about the current stack of pages.
- **Push and Pop Operations**: Supports `PushAsync` and `PopAsync` methods for adding and removing pages from the stack.

### Example
```csharp
public partial class MainPage : ContentPage
{
    public MainPage()
    {
        InitializeComponent();
    }

    private async void NavigateButton_Clicked(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new SecondPage());
    }

    private void CheckNavigationStack(object sender, EventArgs e)
    {
        var navigationStack = Navigation.NavigationStack;
        foreach (var page in navigationStack)
        {
            Console.WriteLine(page.Title);
        }
    }
}
```
- **Navigation.NavigationStack**: Returns a list of pages in the stack, allowing you to iterate through them and perform any necessary operations.

### When to Use
- **Accessing Navigation History**: When you need to access or display the list of pages the user has visited.
- **Navigation Management**: Useful for managing the stack manually and performing custom operations based on navigation history.

## 2. ModalStack
The **ModalStack** is used to manage pages that are presented modally. Unlike the **NavigationStack**, modal pages are overlaid on top of other pages and do not follow the same push/pop model.

### Key Features
- **Separate Stack**: Modal pages are managed separately from the **NavigationStack**, and they have their own stack.
- **PushModal and PopModal**: You can add modal pages to the stack using **PushModalAsync** and remove them using **PopModalAsync**.
- **Use for Focused Tasks**: Modal pages are often used for login forms, alerts, or tasks that require user action before proceeding.

### Example
```csharp
private async void ShowModalButton_Clicked(object sender, EventArgs e)
{
    await Navigation.PushModalAsync(new ModalPage());
}

private void CheckModalStack(object sender, EventArgs e)
{
    var modalStack = Navigation.ModalStack;
    Console.WriteLine($"Number of modal pages: {modalStack.Count}");
}
```
- **Navigation.ModalStack**: Returns the current list of modal pages on the stack, allowing you to inspect or manage them.

### When to Use
- **Displaying Forms or Alerts**: When you need to present a page that must be completed or dismissed before the user can proceed.
- **Managing Modal Pages**: Useful for inspecting or managing modal pages, such as checking if certain modals are still active.

## 3. PopToRootAsync
**PopToRootAsync** is a method used to navigate back to the root page of the **NavigationStack**, effectively clearing all intermediate pages.

### Key Features
- **Clears Navigation Stack**: Removes all pages from the stack except the root page, ensuring a consistent navigation point.
- **Simplified Back Navigation**: Provides a convenient way to bring users back to the start of a navigation flow without manually popping each page.
- **Async Method**: Returns a **Task**, allowing it to be awaited to ensure proper completion.

### Example
```csharp
private async void GoToRootButton_Clicked(object sender, EventArgs e)
{
    await Navigation.PopToRootAsync();
}
```
- **PopToRootAsync**: Clears the stack back to the root page, simplifying the navigation experience for users.

### When to Use
- **Resetting the Navigation Flow**: Use **PopToRootAsync** when you want to reset the navigation flow and bring the user back to the main page of the application.
- **After Completing a Task**: When a task has been completed and the user should return to the starting point, such as after completing a multi-step form.

## Summary of Navigation Stack Elements
| Navigation Stack Element  | Description                                       | Use Case                                        |
|---------------------------|---------------------------------------------------|-------------------------------------------------|
| **NavigationStack**       | Stack of pages managed by `NavigationPage`.       | Accessing navigation history or custom management. |
| **ModalStack**            | Stack of modal pages presented modally.           | Forms, alerts, or pages requiring focused user input. |
| **PopToRootAsync**        | Navigates back to the root page, clearing the stack. | Resetting the navigation flow or completing a task.  |

## Commonalities
- **Navigation Management**: All three elements are used to manage the flow of pages within the application.
- **Async Operations**: The methods related to the navigation stack (`PushAsync`, `PopAsync`, `PopToRootAsync`, `PushModalAsync`, etc.) are asynchronous, ensuring a responsive user experience.

## Practical Scenario
Consider a multi-step checkout process in an e-commerce app:
- As users navigate through the checkout process (e.g., address, payment, confirmation), each page is pushed onto the **NavigationStack**.
- If a user needs to review their profile settings during the checkout, a modal page can be presented using **PushModalAsync**, which adds it to the **ModalStack**.
- Once the order is placed, the user can be navigated back to the main shop page using **PopToRootAsync**, clearing all intermediate checkout pages from the stack.

## Reference Sites
- [.NET MAUI Documentation](https://learn.microsoft.com/en-us/dotnet/maui/)
- [Microsoft Learn - NavigationPage](https://learn.microsoft.com/en-us/dotnet/maui/fundamentals/navigation)
- [Modal Navigation in .NET MAUI](https://learn.microsoft.com/en-us/dotnet/maui/fundamentals/navigation#modal-navigation)

# MVVM-Based Navigation Stack in .NET MAUI

## Overview
In **.NET MAUI**, implementing navigation using the **MVVM (Model-View-ViewModel)** pattern is essential for building maintainable, scalable, and testable applications. The **MVVM** pattern allows you to keep UI logic separate from business logic, enhancing modularity. By using MVVM-based navigation, you can manage the **navigation stack** from the **ViewModel** rather than the code-behind, promoting a cleaner and more decoupled architecture.

## Key Components for MVVM Navigation
1. **ICommand for Navigation**: Commands are used to trigger navigation actions, ensuring that navigation logic resides in the ViewModel.
2. **Dependency Injection (DI)**: Navigation services can be injected into the ViewModel to facilitate navigation without the need for direct references to UI components.
3. **Navigation Services**: Services like `INavigation` or **Shell** provide a standardized way to manage navigation within the application.

## MVVM-Based Navigation Methods
### 1. Using ICommand with Navigation Services
Commands are a fundamental aspect of MVVM, used to trigger actions in the **ViewModel**. By using commands with navigation services, you can keep navigation logic separate from the UI.

#### Key Features
- **Command Binding**: Navigation logic is bound to a button or other UI elements using commands defined in the **ViewModel**.
- **Decoupled Logic**: Keeps the navigation code in the **ViewModel**, improving testability and maintainability.
- **Dependency Injection**: The navigation service (`INavigation`) is injected to handle navigation between pages.

#### Example
```csharp
using System.Windows.Input;

public class MainViewModel
{
    private readonly INavigation _navigation;

    public ICommand NavigateCommand { get; }

    public MainViewModel(INavigation navigation)
    {
        _navigation = navigation;
        NavigateCommand = new Command(OnNavigate);
    }

    private async void OnNavigate()
    {
        await _navigation.PushAsync(new SecondPage());
    }
}
```
- **NavigateCommand**: This command is bound to a UI button to initiate the navigation.
- **INavigation**: Handles the navigation logic, allowing the **ViewModel** to manage navigation without direct UI dependencies.

### 2. Shell Navigation with MVVM
**Shell** is a powerful feature in .NET MAUI that allows easy navigation using URIs. The Shell provides a more declarative approach to navigation, making it suitable for MVVM.

#### Key Features
- **URI-Based Navigation**: Pages can be navigated using URI-like strings, simplifying the navigation process.
- **Global Navigation Context**: **Shell.Current.GoToAsync** allows for easy navigation without direct references to the pages.
- **Deep Linking**: Supports deep linking, enabling navigation to specific parts of the application.

#### Example
```csharp
public class MainViewModel
{
    public ICommand NavigateToDetailCommand { get; }

    public MainViewModel()
    {
        NavigateToDetailCommand = new Command(OnNavigateToDetail);
    }

    private async void OnNavigateToDetail()
    {
        await Shell.Current.GoToAsync("//DetailPage");
    }
}
```
- **NavigateToDetailCommand**: Command that navigates to the `DetailPage` using **Shell**.
- **Shell.Current.GoToAsync**: Uses a URI to navigate, providing a centralized navigation approach.

### 3. Navigation Service Abstraction
Abstracting navigation into a separate service is another common practice when using MVVM. This involves creating a custom **INavigationService** that can be injected into any **ViewModel**.

#### Key Features
- **Custom Navigation Logic**: Create a custom service to handle all navigation-related logic, reducing redundancy.
- **Testable**: By abstracting navigation into a service, you can easily mock and test the navigation logic.

#### Example
**INavigationService Interface**:
```csharp
public interface INavigationService
{
    Task NavigateToAsync(Page page);
    Task NavigateBackAsync();
}
```

**NavigationService Implementation**:
```csharp
public class NavigationService : INavigationService
{
    private readonly INavigation _navigation;

    public NavigationService(INavigation navigation)
    {
        _navigation = navigation;
    }

    public async Task NavigateToAsync(Page page)
    {
        await _navigation.PushAsync(page);
    }

    public async Task NavigateBackAsync()
    {
        await _navigation.PopAsync();
    }
}
```
- **NavigateToAsync**: Method to push a new page to the navigation stack.
- **NavigateBackAsync**: Method to pop the current page off the stack.

## Comparison of MVVM Navigation Methods
| Navigation Method          | Description                                    | Use Case                                      |
|----------------------------|------------------------------------------------|-----------------------------------------------|
| **ICommand with INavigation** | Uses commands with `INavigation` for navigation | General navigation, simple page transitions   |
| **Shell Navigation**       | URI-based navigation using **Shell**           | Applications with complex hierarchies, tabs   |
| **Navigation Service**     | Custom navigation service for abstraction      | Reusable navigation logic, testing purposes   |

## When to Use Each Navigation Method
### 1. **ICommand with INavigation**
- **Use Case**: Suitable for simpler applications where direct navigation is needed without complex structure.
- **Example**: Navigating from a product list page to a product detail page.

### 2. **Shell Navigation**
- **Use Case**: Ideal for applications with a **unified navigation experience** involving flyout menus, tabs, or deep links.
- **Example**: Navigating between major sections of an e-commerce application like Home, Categories, and Cart.

### 3. **Navigation Service Abstraction**
- **Use Case**: When you need **reusable and testable navigation logic**. This is common in large projects where navigation needs to be standardized across different **ViewModels**.
- **Example**: Using a custom navigation service to navigate through a multi-step onboarding flow.

## Summary Table of MVVM Navigation Methods
| Feature                 | ICommand with INavigation     | Shell Navigation           | Navigation Service         |
|-------------------------|-------------------------------|----------------------------|----------------------------|
| **Navigation Type**     | Command-based                | URI-based, Shell-driven    | Service abstraction        |
| **Testability**         | Moderate                     | Moderate                   | High                        |
| **Ease of Use**         | Straightforward              | Simplified for complex flows | Reusable for multiple pages |
| **Best Use Case**       | Simple hierarchical flows    | Complex, multi-tab navigation | Standardized navigation logic |

## Practical Scenario
Consider a task management application:
- To navigate between tasks in a **list** and a **detail** page, **ICommand with INavigation** would be suitable for a simple flow.
- For a larger application with sections like **Home**, **Tasks**, and **Settings**, using **Shell Navigation** with tabs or a flyout menu can help create a seamless experience.
- If you need to ensure that navigation across all **ViewModels** is handled in a standardized and reusable way, creating a **Navigation Service** will promote consistency and make unit testing easier.

## Reference Sites
- [.NET MAUI Documentation](https://learn.microsoft.com/en-us/dotnet/maui/)
- [Microsoft Learn - MVVM Pattern](https://learn.microsoft.com/en-us/xamarin/xamarin-forms/enterprise-application-patterns/mvvm)
- [Commands and Navigation in .NET MAUI](https://learn.microsoft.com/en-us/dotnet/maui/fundamentals/commands)

# Modal Navigation in .NET MAUI

## Overview
**Modal Navigation** in **.NET MAUI** allows you to present a new page on top of the current page, requiring the user to interact with that new page before returning to the main content. Modal pages typically appear as full-screen overlays and provide a focused interaction, often used for tasks like login forms, alerts, or configuration screens.

Unlike the traditional navigation flow (using **PushAsync** and **PopAsync**), where pages are added to a navigation stack, modal navigation places pages in a separate stack called the **modal stack**. This allows for a different kind of user interaction, where the modal page must be dismissed explicitly by the user.

## Key Features of Modal Navigation
- **Full-Screen Overlay**: Modal pages take over the entire screen, providing an isolated and focused experience for specific tasks.
- **Separate Navigation Flow**: Modal pages are managed in their own stack, making them independent from the main navigation stack.
- **Explicit Dismissal Required**: Users must explicitly dismiss a modal page to return to the previous screen.
- **Useful for User Input or Confirmation**: Often used for collecting user input, such as login credentials or displaying important information that requires user acknowledgment.

## How to Implement Modal Navigation in .NET MAUI
### 1. PushModalAsync and PopModalAsync
To present a modal page, you can use the **PushModalAsync** method, and to dismiss it, use **PopModalAsync**.

#### Example
**MainPage.xaml.cs**:
```csharp
public partial class MainPage : ContentPage
{
    public MainPage()
    {
        InitializeComponent();
    }

    private async void ShowModalButton_Clicked(object sender, EventArgs e)
    {
        await Navigation.PushModalAsync(new ModalPage());
    }
}
```
**ModalPage.xaml.cs**:
```csharp
public partial class ModalPage : ContentPage
{
    public ModalPage()
    {
        InitializeComponent();
    }

    private async void CloseButton_Clicked(object sender, EventArgs e)
    {
        await Navigation.PopModalAsync();
    }
}
```
- **PushModalAsync**: This method presents `ModalPage` as a modal overlay on top of the existing page.
- **PopModalAsync**: This method dismisses the modal page, returning control to the previous page.

### 2. Shell Modal Navigation
If you are using **Shell**, modal navigation can be achieved with **GoToAsync** using a specific URI pattern.

#### Example
```csharp
await Shell.Current.GoToAsync("modal/ModalPage");
```
- The **"modal/ModalPage"** URI presents `ModalPage` modally within the Shell context.

## When to Use Modal Navigation
### 1. **Focused Interaction**
- **Use Case**: When a task requires the user to focus solely on that specific action before they can continue. Modal navigation forces the user to interact with the presented page.
- **Example**: Collecting login information or showing a "Terms and Conditions" page that users need to accept before proceeding.

### 2. **Data Entry or Configuration**
- **Use Case**: Modal pages are great for collecting or configuring data where the user needs to provide input.
- **Example**: Displaying a form for adding a new contact or providing specific user settings.

### 3. **Alerts or Confirmation**
- **Use Case**: When an alert or confirmation message requires the user's attention and response before returning to the main content.
- **Example**: A confirmation prompt for deleting a record or showing important information.

## Summary Table of Modal Navigation
| Feature                  | Description                                             | Common Use Cases                                |
|--------------------------|---------------------------------------------------------|-------------------------------------------------|
| **Full-Screen Overlay**  | Takes over the entire screen to provide focused input   | Login screens, forms, data entry                |
| **Separate Navigation Stack** | Managed independently from the main navigation flow    | Isolated user tasks, blocking workflows         |
| **Explicit Dismissal**   | Requires an explicit action to return to the main page  | User confirmations, modal data input            |

## Practical Scenario
Consider a scenario where your application requires user authentication before accessing certain features. In this case, presenting a **login screen** using **modal navigation** ensures that the user must complete the login process before interacting with the rest of the app. This modal page takes over the screen and requires user action before dismissing it.

Another scenario could be a **form for adding new items**, such as adding an address or a new task. The modal page can be used to collect this information without any distractions, ensuring the user’s focus is solely on the task at hand.

## Reference Sites
- [.NET MAUI Documentation](https://learn.microsoft.com/en-us/dotnet/maui/)
- [Microsoft Learn - NavigationPage](https://learn.microsoft.com/en-us/dotnet/maui/fundamentals/navigation)
- [Shell Navigation in .NET MAUI](https://learn.microsoft.com/en-us/dotnet/maui/fundamentals/shell/navigation)
