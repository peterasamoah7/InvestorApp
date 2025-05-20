import axios from "axios";
import Investor from "../ui/investors";
import InvestorSearch from "../ui/investor-search";
import Pagination from "../ui/pagination";

type InvProps = {
  searchParams: { pageNumber: number, pageSize: number, name: string };
};


export default async function Page({ searchParams }: InvProps) {

    const pageNumber = await searchParams.pageNumber || 1;
    const pageSize = await searchParams.pageSize || 10;
    const name = await searchParams.name;

    const fetchInvestors = async (): Promise<PagedModel<InvestorModel> | null > => {
        try{

            const queryParams = new URLSearchParams()

            if (name)
            {
                queryParams.append('name', name)
            }
            
            queryParams.append('pageNumber', `${pageNumber}`)
            queryParams.append('pageSize', `${pageSize}`)

            let url: string = `${process.env.API_BASE_URL}/Investor/GetInvestors`
            const response = await axios.get<PagedModel<InvestorModel>>(url, { params: queryParams })
            return response.data;
        }
        catch(error){
            console.log('An error occured')
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