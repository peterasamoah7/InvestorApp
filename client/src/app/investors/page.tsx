import axios from "axios";
import Investor from "../ui/investors";
import InvestorSearch from "../ui/investor-search";
import Pagination from "../ui/pagination";

export default async function Page({ searchParams }: {
    searchParams: Promise<{ name: string, pageSize: string, pageNumber: string }>
}) {

    const { pageSize, pageNumber, name } = await searchParams

    const fetchInvestors = async (): Promise<PagedModel<InvestorModel> | null > => {
        try{

            const queryParams = new URLSearchParams()

            if (name)
            {
                queryParams.append('name', name)
            }
            
            queryParams.append('pageNumber', `${pageNumber || 1}`)
            queryParams.append('pageSize', `${pageSize || 10}`)

            let url: string = `${process.env.API_BASE_URL}/Investor/GetInvestors`
            const response = await axios.get<PagedModel<InvestorModel>>(url, { params: queryParams })
            return response.data;
        }
        catch(error){
            console.log(error)
            return null;
        }
    };

    const models = await fetchInvestors();
    console.log(process.env.API_BASE_URL);

    return (
        <>
            <h2>Investors</h2>   
            <InvestorSearch/>
            <Investor models={models}/>
            <Pagination models={models} path="/investors?"/>
        </>
    );
}