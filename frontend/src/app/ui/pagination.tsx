"use client"

import Link  from "next/link"

export default function Pagination<T>({models, path}: {models: PagedModel<T> | null, path: string}){

    return (
        <>
            <nav aria-label="Page navigation">
            <ul className="pagination justify-content-center">
                {(models?.firstPage != null) && <li className="page-item">
                    <Link className="page-link" href={`${path}${models?.firstPage}`} aria-label="First">
                        <span aria-hidden="true">&laquo;&laquo; First</span>
                    </Link>
                </li>}
                {(models?.previousPage != null) && <li className="page-item">
                    <Link className="page-link" href={`${path}${models?.previousPage}`} aria-label="Previous">
                        <span aria-hidden="true">&laquo; Previous</span>
                    </Link>
                </li>}
                {(models?.nextPage != null) && <li className="page-item">
                    <Link className="page-link" href={`${path}${models?.nextPage}`} aria-label="Next">
                        <span aria-hidden="true">Next &raquo;</span>
                    </Link>
                </li>}
                {(models?.lastPage != null) && <li className="page-item">
                    <Link className="page-link" href={`${path}${models?.lastPage}`} aria-label="Last">
                        <span aria-hidden="true">Last &raquo;&raquo;</span>
                    </Link>
                </li>}
            </ul>
        </nav>
        </>
    );
}