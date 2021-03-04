import React from 'react';
import logo from './logo.svg';
import './App.css';
import {store} from "./actions/store";
import {Provider} from "react-redux";
import ThingsToDo from './components/ThingsToDo';
import {ToastProvider} from "react-toast-notifications";

function App() {
  return (
      <Provider store={store}>
          <ToastProvider autoDismiss={true}>
              <div>
                  <ThingsToDo />
              </div>
          </ToastProvider>
      </Provider>
  );
}

export default App;
