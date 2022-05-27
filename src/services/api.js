export const api = async (url, method = 'GET', body = {}) => {
    const headers = {
        'Accept': 'application/json',
        'Content-Type': 'application/json'
    }

    return await fetch(url, {
        headers: method === `POST` ? headers : {}, 
        body: !!body ? JSON.stringify(body) : null, 
        method: method})
            .then(resp => resp.json())
}