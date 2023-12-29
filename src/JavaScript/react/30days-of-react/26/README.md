# context
1. Create a context. (You can call it LevelContext, since it’s for the heading level.)
2. Use that context from the component that needs the data. (Heading will use LevelContext.)
3. Provide that context from the component that specifies the data. (Section will provide LevelContext.)

# Context passes through intermediate components
Context lets you write components that “adapt to their surroundings” and display themselves differently depending on where (or, in other words, in which context) they are being rendered.

# Before you use context
Context is very tempting to use! However, this also means it’s too easy to overuse it. Just because you need to pass some props several levels deep doesn’t mean you should put that information into context.
Here’s a few alternatives you should consider before using context:
1. Start by passing props. If your components are not trivial, it’s not unusual to pass a dozen props down through a dozen components. It may feel like a slog, but it makes it very clear which components use which data! The person maintaining your code will be glad you’ve made the data flow explicit with props.
2. Extract components and pass JSX as children to them. If you pass some data through many layers of intermediate components that don’t use that data (and only pass it further down), this often means that you forgot to extract some components along the way. For example, maybe you pass data props like posts to visual components that don’t use them directly, like <Layout posts={posts} />. Instead, make Layout take children as a prop, and render <Layout><Posts posts={posts} /></Layout>. This reduces the number of layers between the component specifying the data and the one that needs it.

# Use cases for context
- Theming: If your app lets the user change its appearance (e.g. dark mode), you can put a context provider at the top of your app, and use that context in components that need to adjust their visual look.

- Current account: Many components might need to know the currently logged in user. Putting it in context makes it convenient to read it anywhere in the tree. Some apps also let you operate multiple accounts at the same time (e.g. to leave a comment as a different user). In those cases, it can be convenient to wrap a part of the UI into a nested provider with a different current account value.

- Routing: Most routing solutions use context internally to hold the current route. This is how every link “knows” whether it’s active or not. If you build your own router, you might want to do it too.
- Managing state: As your app grows, you might end up with a lot of state closer to the top of your app. Many distant components below may want to change it. It is common to use a reducer together with context to manage complex state and pass it down to distant components without too much hassle.

# Recap
Context lets a component provide some information to the entire tree below it.
To pass context:
Create and export it with export const MyContext = createContext(defaultValue).
Pass it to the useContext(MyContext) Hook to read it in any child component, no matter how deep.
Wrap children into <MyContext.Provider value={...}> to provide it from a parent.
Context passes through any components in the middle.
Context lets you write components that “adapt to their surroundings”.
Before you use context, try passing props or passing JSX as children.

