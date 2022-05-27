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

const product123 = [{name: 'product 1', id: 1}, {name: 'product 2', id: 2}, {name: 'product 3', id: 3}]

export const Products = () => {
    const [products, setProducts] = React.useState(null);
    const [name, setName] = React.useState(null);
    const [description, setDescription] = React.useState(null);
    const [price, setPrice] = React.useState(0);
    const [quantity, setQuantity] = React.useState(0);

    React.useEffect(() => {    
        api("https://localhost:5001/api/products").then(x => setProducts(x))
        if(products==null) setProducts(product123)
    }, []);

    return (
        <div style={{display: 'flex', padding: 5, justifyContent:'space-around'}}>
            <TableContainer sx={{ maxWidth: 900 }} component={Paper}>
                <Table aria-label="simple table">
                    <TableHead>
                        <TableRow>
                            <TableCell>Id</TableCell>
                            <TableCell>Name</TableCell>
                            <TableCell>Price</TableCell>
                            <TableCell>Description</TableCell>
                            <TableCell>Quantity</TableCell>
                        </TableRow>
                    </TableHead>
                    <TableBody>
                    {products?.map((row) => (
                        <TableRow key={row.id} sx={{ '&:last-child td, &:last-child th': { border: 0 } }}>
                            <TableCell>{row.id}</TableCell>
                            <TableCell>{row.name}</TableCell>
                            <TableCell>{row.price}</TableCell>
                            <TableCell>{row.description}</TableCell>
                            <TableCell>{row.quantity}</TableCell>
                        </TableRow>
                    ))}
                    </TableBody>
                </Table>
            </TableContainer>
            <Card sx={{width:700, padding:5}}>
                <CardHeader title="Create product"></CardHeader>
                <CardContent sx={{display:'flex', flexDirection:'column'}}>
                    <FormControl sx={{maxWidth:400}}>
                        <TextField onChange={(e) => setName(e.target.value)} label="Name" />
                    </FormControl>
                    <FormControl sx={{maxWidth:400, mt:2}}>
                        <TextField onChange={(e) => setDescription(e.target.value)} label="Description" />
                    </FormControl>
                    <FormControl sx={{maxWidth:400, mt:2}}>
                        <TextField type={"number"} onChange={(e) => setPrice(e.target.value)} label="Price" />
                    </FormControl>
                    <FormControl sx={{maxWidth:400, mt:2}}>
                        <TextField type={"number"} onChange={(e) => setQuantity(e.target.value)} label="Quantity" />
                    </FormControl>

                    <Button sx={{maxWidth: 400}} onClick={() => api("https://localhost:5001/api/products", 'POST', 
                        {quantity: quantity, description: description, price: price, name: name})}>Create</Button>
                </CardContent>
            </Card>
        </div>
    )
}