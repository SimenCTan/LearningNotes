import * as React from "react";
import { createRoot } from "react-dom/client";
import {
  createBrowserRouter,
  RouterProvider,
  Route,
  Link,
} from "react-router-dom";

const router = createBrowserRouter([
  {
    path: "/",
    element: (
      <div>
        <h1>Hello World</h1>
        <Link to="about">About Us</Link>
      </div>
    ),
  },
  {
  path:'/about',
  element:(
    <div>about</div>
    )
  }
]);

const rootElement = document.getElementById("root");
createRoot(rootElement).render(<RouterProvider router={router}></RouterProvider>);
