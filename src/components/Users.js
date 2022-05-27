import React from "react";
import { 
    CardContent, 
    FormControl, 
    TextField, 
    Paper, 
    CardHeader, 
    Card, 
    Button, 
    TableRow, 
    TableHead, 
    TableContainer, 
    TableCell, 
    Table, 
    TableBody
} from '@mui/material';
import {api} from '../services/api'

export const Users = () => {
    const [users, setUsers] = React.useState(null);
    const [firstName, setFirstName] = React.useState(null);
    const [lastName, setLastName] = React.useState(null);
    const [patronymic, setPatronymic] = React.useState(null);
    const [birthDate, setBirthDate] = React.useState(null);


    React.useEffect(() => {    
        api("https://localhost:5001/api/users").then(x => setUsers(x))
    }, []);

    return (
        <div style={{display: 'flex', padding: 5, justifyContent:'space-around'}}>
            <TableContainer sx={{ maxWidth: 900 }} component={Paper}>
                <Table aria-label="simple table">
                    <TableHead>
                        <TableRow>
                            <TableCell>Id</TableCell>
                            <TableCell>FirstName</TableCell>
                            <TableCell>LastName</TableCell>
                            <TableCell>Patronymic</TableCell>
                            <TableCell>BirthDate</TableCell>
                        </TableRow>
                    </TableHead>
                    <TableBody>
                    {users?.map((row) => (
                        <TableRow key={row.id} sx={{ '&:last-child td, &:last-child th': { border: 0 } }}>
                            <TableCell>{row.id}</TableCell>
                            <TableCell>{row.firstName}</TableCell>
                            <TableCell>{row.lastName}</TableCell>
                            <TableCell>{row.patronymic}</TableCell>
                            <TableCell>{row.birthDate}</TableCell>
                        </TableRow>
                    ))}
                    </TableBody>
                </Table>
            </TableContainer>
            <Card sx={{width:700, padding:5}}>
                <CardHeader title="Create user"></CardHeader>
                <CardContent sx={{display:'flex', flexDirection:'column'}}>
                    <FormControl sx={{maxWidth:400}}>
                        <TextField onChange={(e) => setFirstName(e.target.value)} label="First name" />
                    </FormControl>
                    <FormControl sx={{maxWidth:400, mt:2}}>
                        <TextField onChange={(e) => setLastName(e.target.value)} label="Last name" />
                    </FormControl>
                    <FormControl sx={{maxWidth:400, mt:2}}>
                        <TextField onChange={(e) => setPatronymic(e.target.value)} label="Patronymic" />
                    </FormControl>
                    <FormControl sx={{maxWidth:400, mt:2}}>
                        <TextField type={"date"} onChange={(e) => setBirthDate(e.target.value)} label="BirthDate" />
                    </FormControl>

                    <Button sx={{maxWidth: 400}} onClick={() => api("https://localhost:5001/api/users", 'POST', 
                        {firstName: firstName, lastName: lastName, patronymic: patronymic, birthDate: birthDate})}>Create</Button>
                </CardContent>
            </Card>
        </div>
    )
}