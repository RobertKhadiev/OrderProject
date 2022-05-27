import React from "react";
import { 
    CardContent, 
    FormControl, 
    MenuItem, 
    InputLabel, 
    Select, 
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
import AddIcon from '@mui/icons-material/Add';
import {api} from '../services/api'

const product123 = [{name: 'product 1', id: 1}, {name: 'product 2', id: 2}, {name: 'product 3', id: 3}]

export const Orders = () => {
    const [orders, setOrders] = React.useState(null);
    const [products, setProducts] = React.useState(null);
    const [productFields, setProductFields] = React.useState([{id: 1}]);
    const [selectedProducts, setSelectedProducts] = React.useState([{id: 0, quantity:0}])

    const [userId, setUserId] = React.useState(0);
    const [paymentType, setPaymentType] = React.useState(0);

    React.useEffect(() => {    
        api("https://localhost:5001/api/orders").then(x => setOrders(x))
        api("https://localhost:5001/api/products").then(x => setProducts(x))
        if(products == null) setProducts(product123)
    }, []);

    const getProductIds = (value, index) => {
        let temp = []

        temp.push(...selectedProducts)
        if(index+1 > selectedProducts.length) {
            temp.push({id: value}) 
        }
        else  {
            temp[index].id = value
        }
            
        return temp
    }
    return (
        <div style={{display: 'flex', padding: 5, justifyContent:'space-around'}}>
            <TableContainer sx={{ maxWidth: 900 }} component={Paper}>
                <Table aria-label="simple table">
                    <TableHead>
                        <TableRow>
                            <TableCell>OrderId</TableCell>
                            <TableCell>UserId</TableCell>
                            <TableCell>Products</TableCell>
                            <TableCell>PaymentType</TableCell>
                        </TableRow>
                    </TableHead>
                    <TableBody>
                    {orders?.map((row) => (
                        <TableRow key={row.id} sx={{ '&:last-child td, &:last-child th': { border: 0 } }}>
                            <TableCell component="th" scope="row">{row.id}</TableCell>
                            <TableCell>{row.userId}</TableCell>
                            <TableCell>{row.products?.map((product, index) =>  index + ") " + product.name).join('\n')}</TableCell>
                            <TableCell>{row.paymentType}</TableCell>
                        </TableRow>
                    ))}
                    </TableBody>
                </Table>
            </TableContainer>
            <Card sx={{width:700, padding:5}}>
                <CardHeader title="Create order"></CardHeader>
                <CardContent sx={{display:'flex', flexDirection:'column'}}>
                    <FormControl sx={{maxWidth:400}}>
                        <TextField type={"number"} onChange={(e) => setUserId(e.target.value)} label="User Id" />
                    </FormControl>

                    <FormControl sx={{mt:2, maxWidth:400}}>
                        <InputLabel id="payment-type-label">Payment Type</InputLabel>
                        <Select onChange={(e) => setPaymentType(e.target.value)} labelId="payment-type-label" id="payment-type-label"  label="Payment Type">
                            <MenuItem value={1}>Cash</MenuItem>
                            <MenuItem value={2}>Credit card</MenuItem>
                        </Select>
                    </FormControl>
                    <FormControl sx={{mt:2, maxWidth:400}}>
                        {productFields?.map((field, index) => (
                            <>
                                <InputLabel id={"product-label-" + index}>Select product</InputLabel>
                                {!!products && <Select labelId={"product-label-" + index} id={"product-label-" + index} label="Select product" onChange={(e) => setSelectedProducts(getProductIds(e.target.value, index))}>
                                    {products?.map((product) => (<MenuItem value={product.id}>{product.name}</MenuItem>))}
                                </Select>}
                                <TextField onChange={(e) => setSelectedProducts(selectedProducts.map((product, ind) => ind === index ? {...product, quantity: e.target.value} : product))} type={"number"} label="Quantity" sx={{mt:2}}/>
                            </>)
                        )}

                        <Button onClick={() => setProductFields([...productFields, {id: productFields.length + 1}])}>
                            <AddIcon/>
                        </Button>
                    </FormControl>

                    <Button sx={{maxWidth: 400}} onClick={() => api("https://localhost:5001/api/orders", 'POST', {products: selectedProducts, userId: userId, paymentType: paymentType})}>Create</Button>
                </CardContent>
            </Card>
        </div>
    )
}