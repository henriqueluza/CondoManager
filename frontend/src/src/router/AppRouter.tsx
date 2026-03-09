import { BrowserRouter, Routes, Route, Navigate} from 'react-router-dom'

export default function AppRouter() {
    return (
        <BrowserRouter>
            <Routes>
                <Route path='/login' element={<div>NomeDaPágina</div>}/>
                <Route path='/register' element={<div>NomeDaPágina</div>}/>
                <Route path='/dashboard' element={<div>NomeDaPágina</div>}/>
                <Route path='/condominiums' element={<div>NomeDaPágina</div>}/>
                <Route path='/condominiums/:id' element={<div>NomeDaPágina</div>}/>
                <Route path='/members' element={<div>NomeDaPágina</div>}/>
                <Route path='/employees' element={<div>NomeDaPágina</div>}/>
                <Route path='/visitors' element={<div>NomeDaPágina</div>}/>
                <Route path='/access-logs' element={<div>NomeDaPágina</div>}/>
                <Route path="/" element={<Navigate to="/login" />} />
            </Routes>
        </BrowserRouter>
    )
}