import InvestorCommitment from "@/app/ui/investor-commitments";
import InvestorCommitmentSummary from "@/app/ui/investor-commitment-summary";
import axios from "axios";
import Pagination from "@/app/ui/pagination";

export default async function Page({params, searchParams} : { 
    params: Promise<{ id: string}>;
    searchParams: Promise<{ aID: string, pageSize: string, pageNumber: string }> }){
    const param = await params;
    const { aID, pageSize, pageNumber } = await searchParams;

    const fetchSummary = async (id: string): Promise<Array<CommitmentSummray> | null > => {
        try{
            let url: string = `${process.env.API_BASE_URL}/Investor/GetSummary?id=${id}`
            const response = await axios.get<Array<CommitmentSummray>>(url)
            return response.data;
        }
        catch(error){
            console.log('An error occured')
            return null;
        }
    };

    const fetchCommitments = async (
        id: string, 
        aID: string,
        pageNumber: string,
        pageSize: string
    ): Promise<PagedModel<CommitmentModel> | null > => {
        try{
            let url: string = `${process.env.API_BASE_URL}/Investor/GetCommitment`
            const queryParams = new URLSearchParams()

            queryParams.append('id', id)                    
            queryParams.append('pageNumber', `${pageNumber}`)
            queryParams.append('pageSize', `${pageSize}`)
            queryParams.append('aID', `${aID}`)

            const response = await axios.get<PagedModel<CommitmentModel>>(url, { params: queryParams })
            return response.data;
        }
        catch(error){
            console.log('An error occured')
            return null;
        }
    };

    let summaries = await fetchSummary(param.id);
    let commitments = await fetchCommitments(param.id, aID, pageNumber, pageSize);

    return (
        <>
            <h2>Commitments</h2>   
            <InvestorCommitmentSummary models={summaries} id={param.id}/>
            <br/>
            <InvestorCommitment models={commitments}/>
            <Pagination models={commitments} path={`/investor-commitments/${param.id}?aID=${aID}&`}/>
        </>
    );
}