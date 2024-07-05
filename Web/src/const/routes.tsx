import { RouteObject, createBrowserRouter } from 'react-router-dom';
import React from 'react';
import App from '../App';

const children: RouteObject[] = [
  {
    path: '',
    lazy: () =>
      import('../components/layouts/main-layout/main-layout').then(
        (module) => ({
          Component: module.default
        })
      ),
    children: [
      {
        path: 'registration',
        lazy: () => import('../components/pages/auth-form/auth-form').then(
          (module) => ({
            Component: module.default
          })
        ),
      },
      {
        path: 'login',
        lazy: () => import('../components/pages/auth-form/auth-form').then(
          (module) => ({
            Component: module.default
          })
        ),
      }
    ]
  }
];

export const routes = createBrowserRouter([
  {
    path: '',
    element: <App />,
    children
  }
]);
