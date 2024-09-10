import { Route, Routes } from 'react-router-dom'
import { EmployeesPage } from './pages/EmployeesPage'
import { AboutPage } from './pages/AboutPage'
import { Navigation } from './components/Navigation'

function App() {
  return(
    <>
      <Navigation />
      <Routes>
        <Route path="/" element={ <EmployeesPage />} />
        <Route path="/about" element={ <AboutPage />} />
      </Routes>
    </>
  )
}

export default App